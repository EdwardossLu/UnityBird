using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillarController : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private float speed = 0f;
    [SerializeField] private float startPlatformTimer = 2f;
    [SerializeField] private GameManager manager = null;
    
    [Header("XAsis")]
    [SerializeField] private float pointToReset = -10f;
    [SerializeField] private float resetPoint = 10f;

    [Header("YAxis")]
    [SerializeField] private float topHeight = 3f;
    [SerializeField] private float bottomHeight = -3f;

    private bool gameStatus = false;

    private void Start() 
    {
        StartCoroutine(CheckGameStatus(startPlatformTimer));
        
        float xAxis = Random.Range(bottomHeight, topHeight);
        transform.position = new Vector2 (transform.position.x, xAxis);
    }

    private void Update() 
    {
        if (gameStatus)
            transform.Translate(Vector2.left * speed * Time.deltaTime);

        if (transform.position.x <= pointToReset)
        {
            float xAxis = Random.Range(bottomHeight, topHeight);
            transform.position = new Vector2 (resetPoint, xAxis);
        }
    }

    public void GameOver()
    {
        gameStatus = false;
    }

    private IEnumerator CheckGameStatus(float waitTime)
    {
        while (!manager.GameStatus)
        {
            yield return new WaitForSeconds(waitTime);
        }

        gameStatus = true;
        yield return null;
    }
}
