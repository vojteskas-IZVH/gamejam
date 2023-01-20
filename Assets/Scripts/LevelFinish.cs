using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinish : MonoBehaviour
{
    private LevelHolder levelHolder;
    public int level;

    // Start is called before the first frame update
    void Start()
    {
        levelHolder = GameObject.FindGameObjectWithTag("LevelHolder").GetComponent<LevelHolder>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Finish triggered");
        if(collision.gameObject.layer == 3)
        {
            PlayerPrefs.SetInt("Unlocked_level_"+(level+1).ToString(),1);
            levelHolder.LevelCompleted();
        }

    }
}
