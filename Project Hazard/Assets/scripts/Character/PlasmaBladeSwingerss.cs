using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlasmaBladeSwingerss : MonoBehaviour
{


public GameObject Sword;
public bool canAttack = true;
public float attackCoolDown = .25f;
PlasmaBladeWielder WieldPlasmaStat;



void Start()
{
    WieldPlasmaStat = GameObject.FindObjectOfType<PlasmaBladeWielder>();
}


void Update()
{
    if(Input.GetMouseButtonDown(0))
    {
        if(canAttack)
        {
            PlasmaBladeAttack();
        }
    }


}

public void PlasmaBladeAttack()
{
    canAttack = false;
    Animator anim = Sword.GetComponent<Animator>();
    anim.Play("Sword Swing");
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
    H.HealthPoints -= WieldPlasmaStat.plasSwingDmg;
    }
}
}


