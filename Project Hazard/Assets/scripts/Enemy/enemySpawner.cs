using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    public GameObject parent;
    public int numberToSpawn;
    public int limit = 20;
    public float rate;
    public float startRate;
    float spawnTimer;
    
 
    void Start()
    {
        spawnTimer = startRate;
    }
 
    void Update()
    {
        GameObject target = GameObject.FindWithTag("Player");
        if (target == null)
        {
            Destroy(parent);
            Destroy(gameObject);
        }

        if (parent.transform.childCount < limit)
        {
            spawnTimer -= Time.deltaTime;
            if (spawnTimer <= 0f)
            {
                for (int i = 0; i < numberToSpawn; i++)
                {
                    Instantiate(objectToSpawn, new Vector3(this.transform.position.x + GetModifier(), this.transform.position.y, this.transform.position.z + GetModifier()), transform.rotation * Quaternion.Euler (Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f)), parent.transform);
                }
                spawnTimer = rate;
            }
        }
    }
 
    float GetModifier()
    {
        float modifier = Random.Range(0f, 7f);
        if (Random.Range(0, 7) > 0)
            return -modifier;
        else
            return modifier;
    }
}
