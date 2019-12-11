using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private float speed = 0;
    [SerializeField] private GameManager manager = null;

    private Rigidbody2D rb;
    private bool isJumping = false;
    private bool gameStatus = false;

    private void Awake() 
    {
        Assert.IsNotNull(manager);
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Assert.IsNotNull(rb);

        rb.isKinematic = true;
    } 

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && gameStatus)
            isJumping = true;
    }

    private void FixedUpdate() 
    {
        if (isJumping && gameStatus)
        {
            isJumping = false;
            rb.velocity = Vector2.zero;
            rb.AddForce((Vector2.up * speed), ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Pillar"))
            manager.AddScore();
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if (other.gameObject.CompareTag("Pillar"))
        {
            manager.GameOver();
            gameStatus = false;
        }
    }

    public void StartGame()
    {
        gameStatus = true;
        rb.isKinematic = false;
    }
}
