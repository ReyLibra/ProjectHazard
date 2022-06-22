using UnityEngine;

public class playerCamera : MonoBehaviour {

	private Transform target;
	private float smoothSpeed = 0.125f;
    private Vector3 offset;

    void Start()
    {
        offset = new Vector3(0.0f, 24.0f, -12.0f);
        if(GameObject.FindWithTag("Player") != null)
		{
			target = GameObject.FindWithTag("Player").transform;
		}
    
	}
    
	// If camera is jittery, replace LateUpdate with FixedUpdate
	void LateUpdate()
	{
		Vector3 desiredPosition = target.position + offset;
		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
		transform.position = smoothedPosition;

		transform.LookAt(target);
	}
	void Update()
	{
        if (target == null)
        {
        	this.enabled = false;
        }
	}
}