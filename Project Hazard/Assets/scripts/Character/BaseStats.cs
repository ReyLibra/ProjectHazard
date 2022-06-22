using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStats : MonoBehaviour
{
[SerializeField] public float maxHealth = 100.0f;
 public float currentHealth = 100.0f;//JOSH ADDED
public float baseAttack = 10.0f;
public float attackBonus = 0.0f;
public float healthBonus = 0.0f;
public float critChance = 0.05f;
public float cooldownReduced = 0.0f;
public float moveSpeed = 1.0f;
public float attackSpeed = 1.0f;
public bool playerDead = false;
public string timeSinceLoad;
private float sceneTime;

/*ExpSystem Exp;
HUDScript myHud;*/
YouDied deathUIScript;
public float BaseAttack
{
    get { return  baseAttack;}
    set { baseAttack = value;}
}

public float AttackBonus
{
    get { return  attackBonus;}
    set { attackBonus = value;}
}

public float HealthBonus
{
    get { return  healthBonus;}
    set { healthBonus = value;}
}

public float CritChance
{
    get { return  critChance;}
    set { critChance = value;}
}

public float CooldownReduced
{
    get { return  cooldownReduced;}
    set { cooldownReduced = value;}
}
public float MaxHealth
{

get { return  maxHealth; }
set { maxHealth = value; }

}

public float CurrentHealth
{
    get 
    { 
        return  currentHealth;
    }
    set 
    {
        currentHealth = value;
    }

}
public float MoveSpeed
{
    get { return  moveSpeed;}
    set { moveSpeed = value;}
}

/*public float attackSpeed
{

    get {return  attackSpeed;}
    set {attackSpeed = value;}

}*/
void Start()
{
    /*CurrentHealth = 50.0f;
    Debug.Log("blahsdjadhfh");*/
}
void Update()
{
    sceneTime = Mathf.Round(Time.timeSinceLevelLoad*100.0f)/100.0f;
    timeSinceLoad = "Time Elapsed: " + sceneTime + "Seconds";
    //Debug.Log($"{CurrentHealth} / {MaxHealth}");
}
 public void Damage(int amount)
    {
        if(amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }

        this.CurrentHealth -= amount;

        if(CurrentHealth <= 0)
        {
            Die();
        }
    }
public void increaseStats()
{
    this.maxHealth += 10.0f;
    this.currentHealth += 10.0f;
    this.baseAttack += 2.0f;
}
 private void Die()
    {
        GameObject.FindObjectOfType<enemyTracking>().enabled = false;
        GameObject.FindObjectOfType<enemyAttackDrone>().enabled = false;
        
        //Send the following stats to YouDied.cs before destroying
        GameObject.FindObjectOfType<YouDied>().eoRAtk = BaseAttack;
        GameObject.FindObjectOfType<YouDied>().eoRSpeed = moveSpeed;
        GameObject.FindObjectOfType<YouDied>().eoRMaxHealth = MaxHealth;        
        GameObject.FindObjectOfType<YouDied>().eoRCritRate = CritChance;        
        GameObject.FindObjectOfType<YouDied>().eoRTime = timeSinceLoad;
        playerDead = true;
        //
        Debug.Log("I am Dead!");
        GameObject.FindObjectOfType<YouDied>().RetryScreen();
        Destroy(gameObject);
    }
public void Awake(){

   
}


}













    