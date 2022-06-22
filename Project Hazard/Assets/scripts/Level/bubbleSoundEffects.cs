using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bubbleSoundEffects : MonoBehaviour
{

    public AudioClip bubble1;
    public AudioClip bubble2;
    public AudioSource audio;

    public int sound;

    private float timer;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        timer = 10f;
        sound = 2;
    }

    void Update()
    {
        if (timer >= 0)
            timer -= Time.deltaTime;

        if (timer <= 0)
        {
            sound = Random.Range( 0, 3 );
            timer = 10f;
            switch (sound)
                {
                case 0:
                    audio.PlayOneShot(bubble1, 1.0f);
                    break;
                case 1:
                    audio.PlayOneShot(bubble2, 1.0f);
                    break;
                }
        }
    }

}
