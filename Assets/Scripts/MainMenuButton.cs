using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public bool loadScene;
    public bool isLevel;
    public int sceneIndex;
    public GameObject mainMenu;
    public GameObject levelMenu;
    public int selectedLevel;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClick()
    {
        if(isLevel)
        {
            PlayerPrefs.SetInt("ActiveLevel",selectedLevel);
        }
        if(loadScene)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }

    public void LoadLevels()
    {
        mainMenu.SetActive(false);
        levelMenu.SetActive(true);
    }

    public void LoadMainMenu()
    {
        mainMenu.SetActive(true);
        levelMenu.SetActive(false);
    }
}
