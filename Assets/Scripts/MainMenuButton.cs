using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButton : MonoBehaviour
{
    public bool loadScene;
    public int sceneIndex;

    public void OnClick()
    {
        if(loadScene)
        {
            SceneManager.LoadScene(sceneIndex);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
