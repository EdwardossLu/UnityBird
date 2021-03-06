﻿using System.Collections;
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

    [Header("ListOfCanvas")]
    [SerializeField] private int numOfCanvas = 1;
    [SerializeField] private GameObject[] listOfCanvas = null;

    private bool _gameStatus = false;

    public bool GameStatus
    {
        get { return _gameStatus; }
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

        numOfCanvas = 1;
        ActiveCanavs(numOfCanvas);

        // Display an error when the wrong canvas is displayed towards the player.
        if (numOfCanvas != 1)
            Debug.LogError("numOfCanvas is not set to 0");
    }

    private void Update()
    {
        // Close the application when the escape button is pressed.
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();

        StartGame();
    }

    // Start the game when the player does an input.
    private void StartGame()
    {
        if (Input.GetMouseButtonUp(0) && _gameStatus == false)
        {
            player.StartGame();
            _gameStatus = true;

            numOfCanvas = 2;
            ActiveCanavs(numOfCanvas);
        }
    }

    // Reset the game.
    public void ResetGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void GameOver()
    {
        _gameStatus = false;
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
    private void ActiveCanavs(int i)
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
