using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelHolder : MonoBehaviour
{
    public PlayerController player;
    public GameObject gameOverScreen;
    public int levelCount;
    public Text levelNumberText;
    public Text levelCompletedText;

    private Vector3 originalPosition;
    private int activeLevelNumber;
    private int nextLevelNumber;
    private GameObject activeLevel;
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
        levelNumberText.text = "Level " + nextLevelNumber;
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
        player.OnGameStart();
        gameOverScreen.SetActive(false);
        player.transform.position = originalPosition;
    }

}
