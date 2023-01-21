using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject player;
    public GameObject leftBorder;
    public GameObject rightBorder;

    private float left;
    private float right;

    // Start is called before the first frame update
    void Start()
    {
        left = leftBorder.transform.position.x + 8.7f;
        right = rightBorder.transform.position.x - 8.7f; 
    }

    // Update is called once per frame
    void Update()
    {
        if(player.transform.position.x > left && player.transform.position.x < right)
        {
            transform.position = new Vector3(player.transform.position.x,player.transform.position.y,transform.position.z);
        }
        else // hit the edge, go only up and down
        {
            transform.position = new Vector3(transform.position.x, player.transform.position.y, transform.position.z);
        }
        
    }
}
