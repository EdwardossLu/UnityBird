using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Assertions;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText = null;
    [SerializeField] private TextMeshProUGUI endScore = null;
    [SerializeField] private PlayerController player = null;
    [SerializeField] private PillarController pillar = null;

    [Header("ListOfCanvas")]
    [SerializeField] private int numOfCanvas = 1;
    [SerializeField] private GameObject[] listOfCanvas = null;

    private bool gameStatus = false;


    public bool GameStatus  
    {
        get { return gameStatus; }
    }

    public int Score
    {
        get { return score; }
    }


    private void Awake() 
    {
        Assert.IsNotNull(scoreText);
        Assert.IsNotNull(player);
        Assert.IsNotNull(listOfCanvas);
        Assert.IsNotNull(pillar);

        numOfCanvas = 1;
        ActiveCanavs(numOfCanvas);

        if (numOfCanvas != 1)
            Debug.LogError("numOfCanvas is not set to 0");
    }

    public void StartGame()
    {
        player.StartGame();
        gameStatus = true;

        numOfCanvas = 2;
        ActiveCanavs(numOfCanvas);
    }

    // Reset the game.
    public void ResetGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void GameOver()
    {
        gameStatus = false;
        endScore.text = score.ToString();

        numOfCanvas = 3;
        ActiveCanavs(numOfCanvas);
    }

    public void AddScore()
    {
        ++score;
        scoreText.text = score.ToString();
    }

    // Change canvas based on int value.
    private void ActiveCanavs( int i )
    {
        switch (i)
        {
            case 1:     // Main Menu 
                listOfCanvas[0].SetActive(true);
                listOfCanvas[1].SetActive(false);
                listOfCanvas[2].SetActive(false);
                break;

            case 2:     // Gameplay
                listOfCanvas[0].SetActive(false);
                listOfCanvas[1].SetActive(true);
                listOfCanvas[2].SetActive(false);
                break;

            case 3:     // Game Over
                listOfCanvas[0].SetActive(false);
                listOfCanvas[1].SetActive(false);
                listOfCanvas[2].SetActive(true);
                break;

            default:    // Main Menu (Default)
                listOfCanvas[0].SetActive(true);
                listOfCanvas[1].SetActive(false);
                listOfCanvas[2].SetActive(false);
                break;
        }
    }
}
