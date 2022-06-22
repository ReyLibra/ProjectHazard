using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthyEnemy : ExpSystem
{
    public float StartingEnemyHealth;
    public float ExpValue;
    private GameObject player;

    public float HealthPoints;

    PlayerHitIndication PlayerHitIndication;

    // _HealthPoints = Mathf.Clamp(value,0f,100f);
    //[SerializeField]public float _HealthPoints;

    void Start()
    {
        if(this.tag == "Drone_1")
        {
            ExpValue = 10.0f;
            HealthPoints = 25.0f;
        }

        if(this.tag == "Drone_2")
        {
            ExpValue = 25.0f;
            HealthPoints = 50.0f;
        }
        StartingEnemyHealth = HealthPoints;
        //HealthPoints = StartingEnemyHealth;
        player = GameObject.FindGameObjectWithTag("Player");
        PlayerHitIndication = GameObject.FindObjectOfType<PlayerHitIndication>();
    }

    void Update()
    {
        if(HealthPoints <= 0f)
        {
            Die();
            player.GetComponent<ExpSystem>().SetExperience(ExpValue);
        }
    }

    void Die()
    {
        PlayerHitIndication.EnemyDEADSound();
        Destroy(gameObject);
    }
}
