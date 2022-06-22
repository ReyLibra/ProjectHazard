using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosive : MonoBehaviour
{
    public Elevator Elevator;
    public pickUpItem pickUpItem;

    void Start()
    {
        Elevator = FindObjectOfType<Elevator>();
        pickUpItem = FindObjectOfType<pickUpItem>();
    }
    
    void Update()
    {
    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            pickUpItem.playsound();
            Elevator.explosive = true;
            Destroy(this.gameObject);
        }
    }
}
