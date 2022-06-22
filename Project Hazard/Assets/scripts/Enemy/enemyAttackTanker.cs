using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttackTanker : MonoBehaviour
{
    private BaseStats playerHealth;
    private bool ATTACK = false;

    public float startRate = 1.5f;
    public float fireRate;
    public Transform bullet;
    public Transform shootPos;

    public AudioClip Laser_F;
    public AudioSource audio;

    void Start()
    {
        playerHealth = FindObjectOfType<BaseStats>();
        fireRate = startRate;
        Physics.IgnoreLayerCollision(6,6);
        Physics.IgnoreLayerCollision(6,7);

        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (playerHealth == null) 
        {
            //Destroy(gameObject);
            this.enabled = false;

        }
        else if (ATTACK == true) 
        {
            if (fireRate >= 0) 
            {
                fireRate -= Time.deltaTime;
            }

            else if (fireRate <= 0) 
            {
                shootBullet();
                fireRate = 2.0f;
            }
        }
    }

    public void shootProjectile(bool trigger)
    {
        ATTACK = trigger;
    }

    public void shootBullet()
    {
        audio.PlayOneShot(Laser_F, 1.0f);
        Instantiate(bullet, shootPos.position, shootPos.rotation);
    }
}