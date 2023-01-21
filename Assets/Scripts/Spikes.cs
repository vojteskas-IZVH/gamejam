using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Spikes : MonoBehaviour
{
    private PolygonCollider2D mBoxTrigger;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        var colliders = GetComponents<PolygonCollider2D>();
        mBoxTrigger = colliders[0]; Assert.IsTrue(mBoxTrigger.isTrigger);
    }

    public void OnTriggerEnter2D(Collider2D other) // other == another collider
    {
        if (other.CompareTag("Player"))
        {
            LevelHolder.Instance.GameOver();
        }
    }

}
