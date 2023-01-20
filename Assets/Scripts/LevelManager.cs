using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int levelCount;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("Unlocked_level_1",1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int GetLevelCount()
    {
        return levelCount;
    }
}
