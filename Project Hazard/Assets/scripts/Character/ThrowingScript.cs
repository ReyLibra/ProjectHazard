using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowingScript : MonoBehaviour
{
    
    public Transform cam;
    public Transform attackPoint;
    public GameObject ThrowingTrident;

    public int TotalThrows;
    public float ThrowCooldown;

    public KeyCode throwKey = KeyCode.Mouse1;
    public float throwForce;
    public float throwUpwardForce;

    bool readyToThrow;
    public float curThrowCD; 

    public void Start()
        {
            readyToThrow = true;
            curThrowCD = 0.0f;
        }
    public void Update()
    {
        if(Input.GetKeyDown(throwKey) && readyToThrow && TotalThrows >0)
        {
            Throw();
        }
        if(!readyToThrow)
        {
            curThrowCD += Time.deltaTime;
        }
    }

    public void Throw()
    {
        readyToThrow = false;

        //instantiate object to throw.

        GameObject projectile = Instantiate (ThrowingTrident, attackPoint.position, cam.rotation);

        //Get rigidbody component

        Rigidbody projectileRB = projectile.GetComponent<Rigidbody>();

        //Calculate Direction

        Vector3 forceDirection =cam.transform.forward;
        RaycastHit hit;
        if(Physics.Raycast(cam.position, cam.forward, out hit, 500f))
        {
            forceDirection = (-(hit.point - attackPoint.position)).normalized;
        }

            //Add Force

            Vector3 forceToAdd = forceDirection * throwForce + transform.up * throwUpwardForce;


        // This designates the force be applied once rather than consistently
            projectileRB.AddForce(forceToAdd, ForceMode.Impulse);



        //Decreases the amount of throws left
            //TotalThrows--;

        //This Implements the Coold Down of throwing tridents
        
        //Debug.Log(curThrowCD);
        Invoke(nameof(ResetThrow), ThrowCooldown);
    }
    public void ResetThrow()
    {
        readyToThrow = true;
        curThrowCD = 0.0f;
    }
}