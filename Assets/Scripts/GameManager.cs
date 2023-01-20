using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
    public AudioSource deathSound;
    public AudioSource victorySound;
    public AudioSource goblinDeathSound;
    
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

        public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = score.ToString();
    }

    public void EndGame()
    {
        //Play only once
        if (!deathSound.IsUnityNull())
        {
            deathSound.Play();
            deathSound = null;
        }
        
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

    public Vector3 getPlayerPosition()
    {
        return player.transform.position;
    }
}
