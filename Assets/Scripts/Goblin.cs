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
    public AudioSource deathSound;

    private void Awake()
    {
        var colliders = GetComponents<BoxCollider2D>();
        mBoxTrigger = colliders[0]; Assert.IsTrue(mBoxTrigger.isTrigger);
        mRigidBody = GetComponent<Rigidbody2D>();
    }

    public void OnTriggerEnter2D(Collider2D other) // other == another collider
    {
        
        if (other.CompareTag("Sword") || other.CompareTag("Finish"))
        {
            DestroyGoblin();
        }

        if (other.CompareTag("Player"))
        {
            GameManager.Instance.EndGame();
        }
    }

    public void DestroyGoblin()
    {
        GameManager.Instance.goblinDeathSound.Play();
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
