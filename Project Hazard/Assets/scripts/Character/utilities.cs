using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class utilities : MonoBehaviour
{
    private KeyCode Ability_1 = KeyCode.Q;
    private KeyCode Ability_2 = KeyCode.E;
    private BaseStats BaseStats;
    public Player_Movement Player_Movement;
    private enemyBullet enemyBullet;

    public bool active1 = false;
    public bool active2 = false;
    public float healPercent;
    public float oldMoveSpeedHeal;
    public float moveSpeedHeal;
    public float moveSpeedHealDecay;

    public bool dmgReduc = false;
    private float damageValueDecay;

    public float cooldown_1;
    public float cooldown_2;
    private int util_1 = 3;
    private int util_2 = 2;

    public AudioClip audioHeal;
    public AudioClip audioDmgReduc;
    public AudioSource audio;

    void Start()
    {
        BaseStats = FindObjectOfType<BaseStats>();
        Player_Movement = FindObjectOfType<Player_Movement>();
        audio = GetComponent<AudioSource>();
        oldMoveSpeedHeal = Player_Movement.speed;

    }

    void Update()
    {
        if(Input.GetKeyDown(Ability_1) && cooldown_1 <= 0.0f)
        {
            switch (util_1)
            {
            case 1:
                pushBubble();
                break;
            case 2:
                heal();
                audio.PlayOneShot(audioHeal, 1.0f);
                cooldown_1 = 40.0f;
                active1 = false;
                break;
            case 3:
                damageReduction();
                audio.PlayOneShot(audioDmgReduc, 1.0f);
                cooldown_1 = 20.0f;
                active1 = false;
                break;
            case 4:
                depthCharge();
                break;
            case 5:
                protShield();
                break;
            }
        }

        if(Input.GetKeyDown(Ability_2) && cooldown_2 <= 0.0f)
        {
            switch (util_2)
            {
            case 1:
                pushBubble();
                break;
            case 2:
                heal();
                audio.PlayOneShot(audioHeal, 1.0f);
                cooldown_2 = 40.0f;
                active2 = false;
                break;
            case 3:
                damageReduction();
                audio.PlayOneShot(audioDmgReduc, 1.0f);
                cooldown_2 = 20.0f;
                active2 = false;
                break;
            case 4:
                depthCharge();
                break;
            case 5:
                protShield();
                break;
            }
        }
        
        if (cooldown_1 > 0.0f)
        {
            cooldown_1 -= Time.deltaTime;
        }
        else if (cooldown_1 <= 0.0f && !active1)
        {
            ready_1();
        }
        


        if (cooldown_2 > 0.0f)
        {
            cooldown_2 -= Time.deltaTime;
        } 
        else if (cooldown_2 <= 0.0f && !active2)
        {
            ready_2();
        }


        if (moveSpeedHealDecay > 0.0f)
        {
            moveSpeedHealDecay -= Time.deltaTime;
        }
        else if (moveSpeedHealDecay <= 0.0f)
        {
            moveSpeedHealDecay = 0.0f;
            Player_Movement.speed = oldMoveSpeedHeal;
        }

        if (damageValueDecay > 0.0f)
        {
            damageValueDecay -= Time.deltaTime;
        } 
        else if (damageValueDecay <= 0.0f)
        {
            damageValueDecay = 0.0f;
            dmgReduc = false;
        }
    }

    public void ready_1()
    {
        //Debug.Log("Utility 1 Ready");
        active1 = true;
    }

    public void ready_2()
    {
        //Debug.Log("Utility 2 Ready");
        active2 = true;
    }

    public void pushBubble()
    {

    } 

    public void heal()
    {
        healPercent = Mathf.Ceil(BaseStats.MaxHealth*0.3f);
        //Debug.Log(healPercent);
        if(BaseStats.currentHealth + healPercent >= BaseStats.MaxHealth)
        {
            BaseStats.currentHealth = BaseStats.MaxHealth;
        }
        if(BaseStats.currentHealth + healPercent < BaseStats.MaxHealth)
        {
            BaseStats.currentHealth = BaseStats.currentHealth + healPercent;
        }
        
        Player_Movement.speed = oldMoveSpeedHeal;
        moveSpeedHeal = (Player_Movement.speed*1.3f);
        Player_Movement.speed = moveSpeedHeal;
        moveSpeedHealDecay = 3.0f;
    } 
    
    public void damageReduction()
    {
        dmgReduc = true;
        damageValueDecay = 10.0f;
    } 
    
    public void depthCharge()
    {
        
    } 
    
    public void protShield()
    {
        
    } 

}
