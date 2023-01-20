using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int score;
    public Text scoreText;
    public GameObject gameOverScreen;
    public GameObject scoreCounter;
    public Text highScoreText;
    public Text yourScoreText;
    public PlayerController player;

    // Singleton instance of the GameManager.
    private static GameManager sInstance;

    // Getter for the singleton GameManager object.
    public static GameManager Instance
    {
        get { return sInstance; }
    }

    private void Awake()
    {
        // Initialize the singleton instance, if no other exists.
        if (sInstance != null && sInstance != this)
        { Destroy(gameObject); }
        else
        { sInstance = this; }
    }

    public void addScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = score.ToString();
    }

    public void endGame()
    {
        highScoreText.text = "High score: " + score.ToString();
        yourScoreText.text = "Your score: " + score.ToString();
        scoreCounter.SetActive(false);
        gameOverScreen.SetActive(true);
        player.OnGameOver();
    }

    public void newGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public Vector3 getPlayerPosition()
    {
        return player.transform.position;
    }
}
