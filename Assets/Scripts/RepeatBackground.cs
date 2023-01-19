using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private float backgroundHeight;
    public BoxCollider2D backgroundCollider;
    // Start is called before the first frame update
    void Start()
    {
        backgroundHeight = backgroundCollider.size.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y > backgroundHeight)
        {
            RepositionBackground();
        }
    }

    void RepositionBackground()
    {
        Vector2 backgroundOffset = new Vector2(0,-backgroundHeight * 2f);
        transform.position = (Vector2)transform.position + backgroundOffset;
    }
}
