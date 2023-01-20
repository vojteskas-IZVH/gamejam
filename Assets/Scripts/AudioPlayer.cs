using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource walkSound;

    public AudioSource swordSound;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void playSound_Walk()
    {
        walkSound.Play();
    }
    public void playSound_Sword()
    {
        swordSound.Play();
    }
}
