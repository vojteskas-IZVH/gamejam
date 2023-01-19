using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float scrollSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.velocity = new Vector2(0,scrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
