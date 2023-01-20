using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleSceneAudioPlayer : MonoBehaviour
{
    public AudioSource soundtrack;
    // Start is called before the first frame update

    private void Awake()
    {
        soundtrack.time = 68; // Start at 68th second
        soundtrack.Play();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
