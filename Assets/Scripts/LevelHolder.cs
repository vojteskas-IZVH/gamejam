using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelHolder : MonoBehaviour
{
    public PlayerController player;
    public GameObject gameOverScreen;
    public GameObject nextButton;
    public int levelCount;
    public Text levelNumberText;
    public Text levelCompletedText;
    public AudioSource deathSound;

    private Vector3 originalPosition;
    private int activeLevelNumber;
    private int nextLevelNumber;
    private GameObject activeLevel;

    // Singleton instance of the LevelHolder.
    private static LevelHolder sInstance;

    // Getter for the singleton LevelHolder object.
    public static LevelHolder Instance
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


    // Start is called before the first frame update
    void Start()
    {
        activeLevelNumber = PlayerPrefs.GetInt("ActiveLevel",1);
        nextLevelNumber = activeLevelNumber;
        activeLevel = StartLevel(activeLevelNumber);
        activeLevel.SetActive(true);
        originalPosition = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject StartLevel(int level)
    {
        GameObject levelObject = transform.Find("Level"+level).gameObject;
        return levelObject;
    }

    public void LevelCompleted()
    {
        GameManager.Instance.VictorySoundPlay();
        levelNumberText.text = "Level " + nextLevelNumber;
        nextButton.SetActive(true);
        gameOverScreen.SetActive(true);
        player.OnGameOver();
    }

    public void GameOver()
    {
        //Play only once
        if (!deathSound.IsUnityNull())
        {
            deathSound.Play();
            deathSound = null;
        }

        levelNumberText.text = "Level " + nextLevelNumber;
        levelCompletedText.text = "Game over";
        nextButton.SetActive(false);
        gameOverScreen.SetActive(true);
        player.OnGameOver();
    }

    public void PlayNext()
    {
        if(nextLevelNumber != levelCount)
        {
            nextLevelNumber += 1;
        }
        player.OnGameStart();
        gameOverScreen.SetActive(false);
        player.transform.position = originalPosition;
        activeLevel.SetActive(false);
        activeLevel = StartLevel(nextLevelNumber);
        activeLevel.SetActive(true);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(1);
    }

}
