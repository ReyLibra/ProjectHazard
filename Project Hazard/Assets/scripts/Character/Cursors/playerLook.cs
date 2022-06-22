using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerLook : MonoBehaviour
{
    // Start is called before the first frame update
    Ray cameraRay; //the sent out ray
    RaycastHit cameraRayHit; //object that the camera's ray hits
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    int layerMask = 1 << 8;
    //layerMask = layerMask;
        cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if(Physics.Raycast(cameraRay, out cameraRayHit, Mathf.Infinity, layerMask))
        {
            if(cameraRayHit.transform.tag == "Ground" || cameraRayHit.transform.tag == "Drone_1" || cameraRayHit.transform.tag == "Drone_2")
            {
                Vector3 targetPosition = new Vector3(cameraRayHit.point.x, transform.position.y, cameraRayHit.point.z);
                transform.LookAt(targetPosition);
            }
        
        }

    }
}
