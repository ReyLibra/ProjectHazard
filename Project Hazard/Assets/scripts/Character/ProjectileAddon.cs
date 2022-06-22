using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAddon : BaseStats
{
    public GameObject ThrowingTrident;    
    public float attackMulti = 0.7f;

    PlayerHitIndication PlayerHitIndication;

    void Start()
    {
        PlayerHitIndication = GameObject.FindObjectOfType<PlayerHitIndication>();
    }

    void OnTriggerEnter(Collider other)
    {
        HealthyEnemy H = other.GetComponent<HealthyEnemy>();
        if( H == null) return;
        {
            PlayerHitIndication.DamageEnemySound();
            H.HealthPoints -= baseAttack * attackMulti; 
            Debug.Log(attackMulti * baseAttack); 
            Destroy(ThrowingTrident);
        }
    
    }

}
