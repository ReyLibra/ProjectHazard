using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAttackDrone : BaseStats
{
    private BaseStats playerHealth;
    private bool ATTACK = false;
    private float fireRate;

    //public float count;
    public float startRate = 0.2f;
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
                /*if (count <= 0.85)
                {
                    count += 0.05f;
                }*/
                fireRate = 1.5f;// - count;
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
