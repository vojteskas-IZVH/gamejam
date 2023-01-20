using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public bool loadScene;
    public int sceneIndex;
    public GameObject mainMenu;
    public GameObject levelMenu;



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
