using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private float speed = 0;

    private Rigidbody2D rb;
    private bool isJumping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            isJumping = true;
    }

    private void FixedUpdate() 
    {
        if (isJumping)
        {
            isJumping = false;
            rb.velocity = Vector2.zero;
            rb.AddForce((Vector2.up * speed), ForceMode2D.Impulse);
        }
    }
}
