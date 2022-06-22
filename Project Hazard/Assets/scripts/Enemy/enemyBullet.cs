using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyBullet : MonoBehaviour
{
    private float speed = 50000f;
    public float damage;
    public string bulletTag;
    Rigidbody rb;
    Transform target;
    public bool dmgReduc = false;
    private utilities utilities;

    public void Start()
    {
        bulletTag = gameObject.tag;
        utilities = FindObjectOfType<utilities>();
        rb = GetComponent<Rigidbody>();
        Locate();
    }
    public void Locate()
    {
        target = GameObject.FindWithTag("Player").transform;
        Vector3 dir = (target.position - transform.position);
        rb.AddForce(dir * speed * Time.deltaTime);
    }
    public void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
        }

        switch (bulletTag)
        {
        case "Bullet_1":
            if (utilities.dmgReduc == true) 
            {
                damage = 1.0f;
            } else
            {  
                damage = 3.0f;
            }
            break;
        case "Bullet_2":
            if (utilities.dmgReduc == true) 
            {
                damage = 4.0f;
            } else
            {  
                damage = 10.0f;
            }
            break;
        }

    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            BaseStats dealDmg = collision.transform.GetComponent<BaseStats>();
            dealDmg.Damage((int)damage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
