using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarController : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private float speed = 0f;
    
    [Header("XAsis")]
    [SerializeField] private float pointToReset = -10f;
    [SerializeField] private float resetPoint = 10f;

    [Header("YAxis")]
    [SerializeField] private float topHeight = 3f;
    [SerializeField] private float bottomHeight = -3f;

    private void Update() 
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        
        if (transform.position.x <= pointToReset)
        {
            float xAxis = Random.Range(bottomHeight, topHeight);
            transform.position = new Vector2 (resetPoint, xAxis);
        }
    }
}
