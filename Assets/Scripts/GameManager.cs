using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("General")]
    [SerializeField] private int score = 0;
    [SerializeField] private TextMeshProUGUI scoreText = null;
    [SerializeField] private PlayerController player = null;

    [Header("ListOfCanvas")]
    [SerializeField] private int numOfCanvas = 1;
    [SerializeField] private GameObject mainMenuCanvas = null;
    [SerializeField] private GameObject gameplayCanvas = null;
    [SerializeField] private GameObject OverCanvas = null;

    private void Awake() 
    {
        Assert.IsNotNull(scoreText);
        Assert.IsNotNull(player);
        Assert.IsNotNull(mainMenuCanvas);
        Assert.IsNotNull(gameplayCanvas);
        Assert.IsNotNull(OverCanvas);

        numOfCanvas = 1;
        ActiveCanavs(numOfCanvas);
    }

    public void StartGame()
    {
        player.StartGame();
        numOfCanvas = 2;
        ActiveCanavs(numOfCanvas);
    }

    public void AddScore()
    {
        ++score;
        scoreText.text = score.ToString();
    }

    private void ResetScore()
    {
        score = 0;
    }

    private int ActiveCanavs( int i )
    {
        switch (i)
        {
            case 1:
                mainMenuCanvas.SetActive(true);
                gameplayCanvas.SetActive(false);
                OverCanvas.SetActive(false);
                break;

            case 2:
                mainMenuCanvas.SetActive(false);
                gameplayCanvas.SetActive(true);
                OverCanvas.SetActive(false);
                break;

            case 3:
                mainMenuCanvas.SetActive(false);
                gameplayCanvas.SetActive(false);
                OverCanvas.SetActive(true);
                break;

            default:
                mainMenuCanvas.SetActive(true);
                gameplayCanvas.SetActive(false);
                OverCanvas.SetActive(false);
                break;
        }

        return i;
    }
}
