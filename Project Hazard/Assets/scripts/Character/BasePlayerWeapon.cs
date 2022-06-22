using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePlayerWeapon 
{

private string playerName;
private int playerLevel;
private BaseStats playerClass;

[SerializeField] public float Maxhealth= 100.0f;
public float baseAttack = 10.0f;
public float attackBonus = 0.0f;
public float healthBonus = 0.0f;
public float critChance = 0.05f;
public float cooldownReduced = 0.0f;
public float moveSpeed = 1.0f;
 
public float BaseAttack
{
    get { return baseAttack;}
    set { baseAttack = value;}
}

public float AttackBonus
{
    get { return attackBonus;}
    set { attackBonus = value;}
}

public float HealthBonus
{
    get { return healthBonus;}
    set { healthBonus = value;}
}

public float CritChance
{
    get { return critChance;}
    set { critChance = value;}
}

public float CooldownReduced
{
    get { return cooldownReduced;}
    set { cooldownReduced = value;}
}

public float MoveSpeed
{
    get { return moveSpeed;}
    set { moveSpeed = value;}
}

public float Health
{
get {return Maxhealth;}
set {Maxhealth = value;}


}



}
