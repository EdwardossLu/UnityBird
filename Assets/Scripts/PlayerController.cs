using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private float speed = 0;
    [SerializeField] private GameManager manager = null;

    private Rigidbody2D _rb;
    private bool _isJumping = false;
    private bool _gameStatus = false;

    private void Awake() 
    {
        Assert.IsNotNull(manager);
    }

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        Assert.IsNotNull(_rb);

        _rb.isKinematic = true;
    } 

    private void Update()
    {
        // Check to see if the player can jump. If you can, lift the player character up.
        if (Input.GetKeyDown(KeyCode.Space) && _gameStatus || Input.GetMouseButtonDown(0) && _gameStatus)
            _isJumping = true;
    }

    private void FixedUpdate() 
    {
        // Simulate a single jump.
        if (_isJumping && _gameStatus)
        {
            _isJumping = false;
            _rb.velocity = Vector2.zero;
            _rb.AddForce((Vector2.up * speed), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        // When the player enters a trigger, add 1 score.
        if (other.gameObject.CompareTag("Pillar"))
            manager.AddScore();
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        // When the player hits a pillar, the game ends.
        if (other.gameObject.CompareTag("Pillar"))
        {
            manager.GameOver();
            _gameStatus = false;
        }
    }

    public void StartGame()
    {
        _gameStatus = true;
        _rb.isKinematic = false;
    }
}
