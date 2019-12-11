using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PillarController : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private float startPlatformTimer = 2f;
    [SerializeField] private GameManager manager = null;

    [Header("peed")]
    [SerializeField] private float currentSpeed = 0f;
    [SerializeField] private float nextSpeed = .50f;
    [SerializeField] private int nextScore = 5;
    [SerializeField] private int capScore = 50;

    [Header("XAsis")]
    [SerializeField] private float pointToReset = -10f;
    [SerializeField] private float resetPoint = 10f;

    [Header("YAxis")]
    [SerializeField] private float topHeight = 3f;
    [SerializeField] private float bottomHeight = -3f;

    private bool gameStatus = false;
    private int newScore = 5;


    private void Awake() 
    {
        Assert.IsNotNull(manager);
    }

    private void Start() 
    {
        StartCoroutine(CheckGameStatus(startPlatformTimer));
        
        float xAxis = Random.Range(bottomHeight, topHeight);
        transform.position = new Vector2 (transform.position.x, xAxis);
    }

    private void Update() 
    {
        if (gameStatus)
            transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);

        if (transform.position.x <= pointToReset)
        {
            float xAxis = Random.Range(bottomHeight, topHeight);
            transform.position = new Vector2 (resetPoint, xAxis);
        }

        SetPlatformSpeed();
        print(currentSpeed);
    }

    private void SetPlatformSpeed()
    {
        int currentScore = manager.Score;

        if (newScore == capScore)
        {
            newScore = capScore;
        }
        else if (currentScore == newScore)
        {
            currentSpeed += nextSpeed;
            newScore += nextScore;
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
