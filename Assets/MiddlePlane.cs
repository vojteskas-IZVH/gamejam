using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddlePlane : MonoBehaviour
{
    public GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.layer == 3){
            gameManager.addScore();
        }
        
    }
}
