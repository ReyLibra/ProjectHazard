using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimMove : MonoBehaviour
{
public Animator anim;
public KeyCode Dodge;
public KeyCode Forward;
public KeyCode Backward;
public KeyCode Left;
public KeyCode Right;





void Awake()
{
    anim = GetComponent<Animator>();
}

    // Update is called once per frame
  void Update()
    {
      //wALK FORWARD PLAY AND STOP ANIMATION
          if (Input.GetKeyUp(Forward)) 
    anim.Play("StopDodge");
         if (Input.GetKeyDown(Forward)) 
    anim.Play("Walk");
    //WALK LEFT PLAY AND STOP ANIMATION
         if (Input.GetKeyDown(Left)) 
    anim.Play("Walk");
          if (Input.GetKeyUp(Left)) 
    anim.Play("StopDodge");
    //WALK BACK PLAY AND STOP ANIMATION
         if (Input.GetKeyDown(Backward)) 
    anim.Play("Walk");
  if (Input.GetKeyUp(Backward)) 
    anim.Play("StopDodge");
    //WALK RIGHT PLAY AND STOP ANIMATION
         if (Input.GetKeyDown(Right)) 
    anim.Play("Walk");
   if (Input.GetKeyUp(Right)) 
    anim.Play("StopDodge");
    // DODGE PLAY AND STOP ANIMATION
         if (Input.GetKeyDown(Dodge)) 
    anim.Play("Dodge");
         if(Input.GetKeyUp(Dodge))
    anim.Play("StopDodge");
    }
}
