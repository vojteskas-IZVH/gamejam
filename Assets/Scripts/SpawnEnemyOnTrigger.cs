using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyOnTrigger : MonoBehaviour
{
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            enemy.SetActive(true);
        }

    }


}
