using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements; //for UI stuff later


public class chargePadScript : MonoBehaviour
{
    public float fullChargeTime = 10.0f;
    private float currentChargeTime = 0.0f;
    private bool playerOnPad = false;
    private bool thisPadCharged = false;
    private stage2 stage2Script;

    public AudioClip chargingSound;
    public AudioClip chargedSound;
    public AudioSource audio;

    void Start()
    {
        stage2Script = FindObjectOfType<stage2>();
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        if(playerOnPad && currentChargeTime < fullChargeTime)
        {
            stage2Script.playercharging = true; 
            //tell the ui that the pylon is charging
            //Debug.Log("Charging...");
            currentChargeTime += Time.deltaTime;
        }

        if(playerOnPad && currentChargeTime >= fullChargeTime && thisPadCharged == false) //should only run once
        {
            //Debug.Log("This pylon is fully charged");
            stage2Script.chargedPads += 1;
            if(stage2Script.chargedPads == 3)
            {
                stage2Script.canExit = true;
            }
            
            playerOnPad = false;
            stage2Script.playercharging = false;
            thisPadCharged = true;
            audio.PlayOneShot(chargedSound, 1.0f);
        
        }

        /*if(!playerOnPad && currentChargeTime < fullChargeTime)
        {
            stage2Script.playercharging = false;

        }*/
        if(!playerOnPad && currentChargeTime >= fullChargeTime)
        {
            return;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player"){
            playerOnPad = true;
            //Debug.Log("Charging...");
        }

        if(playerOnPad && currentChargeTime < fullChargeTime)
            {
                audio.PlayOneShot(chargingSound, 1.0f);
            }
    }
    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Player"){
            playerOnPad = false;
            stage2Script.playercharging = false;
        }
    }
}
