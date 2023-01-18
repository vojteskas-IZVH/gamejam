using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    public float jumpStrenght;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move(){
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            myRigidBody.velocity = Vector2.up * jumpStrenght;
        }

        if( Input.GetKeyDown(KeyCode.LeftArrow)){
            myRigidBody.velocity = Vector2.left * jumpStrenght;
        }

        if( Input.GetKeyDown(KeyCode.RightArrow)){
            myRigidBody.velocity = Vector2.right * jumpStrenght;
        }
    }
}
