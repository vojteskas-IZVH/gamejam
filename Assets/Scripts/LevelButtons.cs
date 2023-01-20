using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButtons : MonoBehaviour
{
    private LevelHolder levelHolder;
    // Start is called before the first frame update
    void Start()
    {
        levelHolder = GameObject.FindGameObjectWithTag("LevelHolder").GetComponent<LevelHolder>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void PlayAgain()
    {
        levelHolder.PlayAgain();
    }

    public void PlayNext()
    {
        levelHolder.PlayNext();
    }
}
