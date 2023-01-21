using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneMoveController : MonoBehaviour
{
    public float moveSpeed = 2;
    public float deadZone = 9;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.up * (moveSpeed * Time.deltaTime);

        if(transform.position.y > deadZone)
        {
            Destroy(gameObject);
        }
    }
}
