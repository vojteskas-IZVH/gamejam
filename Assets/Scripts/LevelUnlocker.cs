using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUnlocker : MonoBehaviour
{
    public Text levelText;
    public int levelNumber;
    private LevelManager levelManager;

    private GameObject child;
    // Start is called before the first frame update
    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>();
        for (int j = 0; j < levelManager.GetLevelCount(); j++)
        {
            if(PlayerPrefs.GetInt("Unlocked_level_"+(j+1).ToString(),0) == 1 && levelNumber == j+1)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    child = this.gameObject.transform.GetChild(i).gameObject;
                    child.SetActive(false);
                }
                levelText.text = levelNumber.ToString();
            }
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
