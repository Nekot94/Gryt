using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
    public float smooth = 0.5f;
    
	void Update ()
	{
        if (target == null)
            return;
        Vector3 desiredPosition = new Vector3(target.transform.position.x,
            target.transform.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position,
            desiredPosition, smooth * Time.deltaTime);
	}
}
