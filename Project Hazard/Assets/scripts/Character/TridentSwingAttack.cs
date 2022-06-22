using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TridentSwingAttack : MonoBehaviour
{

public GameObject Trident_Attack_01;
public bool canAttack = true;
public float attackCoolDown = 1.0f;
TridentWielding WieldTridentStat;

PlayerHitIndication PlayerHitIndication;

void Start()
{
    WieldTridentStat = GameObject.FindObjectOfType<TridentWielding>();
    PlayerHitIndication = GameObject.FindObjectOfType<PlayerHitIndication>();
}
void Update()
{
    if(Input.GetMouseButtonDown(0))
    {
        if(canAttack)
        {
            TridentAttack();
        }
    }


}

public void TridentAttack()
{
    canAttack = false;
    Animator anim = Trident_Attack_01.GetComponent<Animator>();
    anim.Play("Sword_Swing");
    StartCoroutine(ResetAttackCD());
}
IEnumerator ResetAttackCD()
{
    yield return new WaitForSeconds(attackCoolDown);
    canAttack = true;
}

public void OnTriggerEnter(Collider other)
{
    HealthyEnemy H = other.GetComponent<HealthyEnemy>();
    if( H == null) return;
    {
        PlayerHitIndication.DamageEnemySound();
        H.HealthPoints -= WieldTridentStat.tridSwingDmg;
    }
    /*if(H != null)
    {
        PlayerHitIndication.DamageEnemySound();
        H.HealthPoints -= WieldTridentStat.tridSwingDmg;
        //Debug.Log(H.HealthPoints);
        //Debug.Log(GameObject.FindGameObjectWithTag("Player").);
    }*/
}
}
