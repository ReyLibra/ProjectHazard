using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class enemyTracking : MonoBehaviour
{
    public Transform target;
    public bool follow = false;
    public string enemyTag;
    //public float waitTimer = 10;

    private float wanderRadius = 20.0f;
    private float wanderTimer = 5.0f;
    public float timer;
    
    private NavMeshAgent navMeshAgent;
    private BaseStats baseStatsScript;

    private enemyAttackDrone enemyAttackDrone;
    private enemyAttackTanker enemyAttackTanker;

    // Start is called before the first frame update
    void Start()
    {
        baseStatsScript = FindObjectOfType<BaseStats>();
        enemyTag = gameObject.tag;
        timer = wanderTimer;
        switch (enemyTag)
        {
        case "Drone_1":
            enemyAttackDrone = this.GetComponent<enemyAttackDrone>();
            break;
        case "Drone_2":
            enemyAttackTanker = this.GetComponent<enemyAttackTanker>();
            break;
        }
        target = GameObject.FindWithTag("Player").transform;
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) 
        {
            Destroy(gameObject);
        }
        else 
        {
            switch (enemyTag)
            {
            case "Drone_1":
                if (Vector3.Distance(target.position, transform.position) <= 10.0) 
                {
                    enemyAttackDrone.shootProjectile(true);
                    follow = true;
                    //waitTimer = 0;
                } else if (Vector3.Distance(target.position, transform.position) >= 30.0)
                {
                    enemyAttackDrone.shootProjectile(false);
                    follow = false;
                }
                break;
            case "Drone_2":
                if (Vector3.Distance(target.position, transform.position) <= 20.0f) 
                {
                    enemyAttackTanker.shootProjectile(true);
                    //navMeshAgent.stoppingDistance = 40;
                    follow = true;
                    //waitTimer = 0;
                } else if (Vector3.Distance(target.position, transform.position) >= 40.0f)
                {
                    enemyAttackTanker.shootProjectile(false);
                    //navMeshAgent.stoppingDistance = 20;
                    //navMeshAgent.angularSpeed = 180;
                    follow = false;
                }
                break;
            }
            /*
            // Timer - Testing Purposes
            if (waitTimer > 0) 
            {
                waitTimer -= Time.deltaTime;
            }
            else
            {
                waitTimer = 0;
                follow = true;
            }
            */

            if (follow == true)
            {
                // Follow Player
                navMeshAgent.destination = target.position;

                // Look At Player
                var lookPos = target.position - transform.position;
                lookPos.y = 0;
                var rotation = Quaternion.LookRotation(lookPos);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 100);
            } else {
                timer += Time.deltaTime;
 
                if (timer >= wanderTimer) {
                    Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                    navMeshAgent.SetDestination(newPos);
                    timer = 0;
                }
            }
        }  
    }
    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask) {
        Vector3 randDirection = Random.insideUnitSphere * dist;
 
        randDirection += origin;
 
        NavMeshHit navHit;
 
        NavMesh.SamplePosition (randDirection, out navHit, dist, layermask);
 
        return navHit.position;
    }
}
