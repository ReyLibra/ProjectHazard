using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpItem : MonoBehaviour
{
    public AudioClip pickUp;
    public AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void playsound()
    {
        audio.PlayOneShot(pickUp, 1.0f);
    }
}
