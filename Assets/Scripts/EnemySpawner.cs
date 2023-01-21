using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    public GameManager gameManager;
    
    public GameObject enemy;
    public bool isLevel;
    public float spawnFrequencyMean = 4.0f;
    public float spawnFrequencyStd = 2.0f;

    // start spawning only if player has higher score than this
    public float scoreThreshold = 10;

    private float _nextSpawnIn;
    

    private static float RandomNormal(float mean, float std)
    {
        var v1 = 1.0f - Random.value;
        var v2 = 1.0f - Random.value;
        
        var standard = Math.Sqrt(-2.0f * Math.Log(v1)) * Math.Sin(2.0f * Math.PI * v2);
        
        return (float)(mean + std * standard);
    }
    // Start is called before the first frame update
    void Start()
    {
        _nextSpawnIn = RandomNormal(spawnFrequencyMean, spawnFrequencyStd);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (gameManager.score < scoreThreshold) return;
        if (_nextSpawnIn > 0)
        {
            _nextSpawnIn -= Time.deltaTime;
        }
        else
        {
            var spawned= Instantiate(enemy, transform.position, transform.rotation);
            if(isLevel)
            {
                spawned.GetComponentInChildren<Goblin>().isLevel = true;
            }
            
            // spawned.
            _nextSpawnIn = RandomNormal(spawnFrequencyMean, spawnFrequencyStd);
        }
        
    }
}
