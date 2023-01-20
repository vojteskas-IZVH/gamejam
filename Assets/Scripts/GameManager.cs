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

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = score.ToString();
    }

    public void EndGame()
    {
        if(PlayerPrefs.GetInt("Endless_hs",0) < score)
        {
            PlayerPrefs.SetInt("Endless_hs",score);
        }
        highScoreText.text = "High score: " + PlayerPrefs.GetInt("Endless_hs",0).ToString();
        yourScoreText.text = "Your score: " + score.ToString();
        scoreCounter.SetActive(false);
        gameOverScreen.SetActive(true);
        player.OnGameOver();
    }

    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
