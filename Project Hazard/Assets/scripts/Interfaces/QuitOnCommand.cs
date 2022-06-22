using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitOnCommand : MonoBehaviour
{
void Update(){
     if(Input.GetKeyDown(KeyCode.Escape) == true)
     {
         Application.Quit();
     }
 }
}
