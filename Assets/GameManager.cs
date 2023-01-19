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
}
