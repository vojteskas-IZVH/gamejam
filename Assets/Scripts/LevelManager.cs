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
        
        // Uncomment to reset game (set highscore to 0 and lock levels)
        // PlayerPrefs.SetInt("Unlocked_level_2",0);
        // PlayerPrefs.SetInt("Unlocked_level_3",0);
        // PlayerPrefs.SetInt("Unlocked_level_4",0);
        // PlayerPrefs.SetInt("Unlocked_level_5",0);
        // PlayerPrefs.SetInt("Unlocked_level_6",0);
        // PlayerPrefs.SetInt("Endless_hs",0);
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
