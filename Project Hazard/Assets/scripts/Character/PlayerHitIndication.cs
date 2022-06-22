using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHitIndication : MonoBehaviour
{

    public AudioClip GetHit;
    public AudioClip HitDrone;
    public AudioClip HitTank;
    public AudioClip EnemyDEAD;
    public AudioSource audio;
    
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Bullet_1")
        {
            audio.PlayOneShot(GetHit, 1.0f);
        }
        if (collision.transform.tag == "Bullet_2")
        {
            audio.PlayOneShot(GetHit, 1.0f);
        }
    }
    public void DamageEnemySound()
    {
        audio.PlayOneShot(HitDrone, 0.5f);
        /*if (transform.tag == "Drone_1")
        {
            audio.PlayOneShot(HitDrone, 1.0f);
        }
        if (transform.tag == "Drone_2")
        {
            audio.PlayOneShot(HitTank, 1.0f);
        }*/
    }
    public void EnemyDEADSound()
    {
        audio.PlayOneShot(EnemyDEAD, 2f);
    }
}
