using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSpawner : MonoBehaviour
{
    public GameObject plane;
    public float spawnRate = 2;
    public float offset = 10;
    private float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnPlane();
    }

    // Update is called once per frame
    void Update()
    {
        if(timer < spawnRate)
        {
            timer += Time.deltaTime;
        }else
        {
            spawnPlane();
            timer = 0;
        }
    }

    void spawnPlane()
    {
        float leftPoint = transform.position.x - offset;
        float rightPoint = transform.position.x + offset;

        Instantiate(plane,new Vector3(Random.Range(leftPoint,rightPoint),transform.position.y,0), transform.rotation);  
    }
}
