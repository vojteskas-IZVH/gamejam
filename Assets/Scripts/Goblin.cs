using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Goblin : MonoBehaviour
{
    public float speed = 1.0f;
    private BoxCollider2D mBoxTrigger;
    private Rigidbody2D mRigidBody;

    private void Awake()
    {
        var colliders = GetComponents<BoxCollider2D>();
        mBoxTrigger = colliders[0]; Assert.IsTrue(mBoxTrigger.isTrigger);
        mRigidBody = GetComponent<Rigidbody2D>();
    }

    public void OnTriggerEnter(Collider other) // other == another collider
    {
        Debug.Log("TriggerEnter " + other.name);
        if (other.CompareTag("Sword") || other.CompareTag("Finish"))
        {
            Debug.Log("Killed a goblin with sword!");
            DestroyGoblin();
        }

        if (other.CompareTag("Player"))
        {
            Debug.Log(("Goblin killed a player!"));
            GameManager.Instance.EndGame();
        }
    }

    public void DestroyGoblin()
    {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var playerPositionX = GameManager.Instance.getPlayerPosition().x;
        var direction = transform.position.x > playerPositionX ? -1 : 1;
        mRigidBody.velocity = new Vector2( direction * speed, mRigidBody.velocity.y);
    }
}
