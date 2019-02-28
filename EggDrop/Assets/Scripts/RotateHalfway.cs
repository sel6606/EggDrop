using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script to constantly rotate the obstacle back and forth.
/// </summary>
public class RotateHalfway : MonoBehaviour {

    public float rotationSpeed;
    public float targetRot;

    private float rot;
    private float totalRot;
    private bool rotatingForward;

	// Use this for initialization
	void Start () {
        rot = 0.0f;
        totalRot = 0.0f;
        rotatingForward = true;
	}
	
	// Update is called once per frame
	void Update () {
        RotateObstacle();
	}

    /// <summary>
    /// Rotates obstacle back and forth between its target rotation.
    /// </summary>
    private void RotateObstacle()
    {
        rot = Time.deltaTime * rotationSpeed;

        //Apply the rotation
        if (rotatingForward)
        {
            totalRot += rot;
            transform.Rotate(Vector3.right, rot);
        }
        else
        {
            totalRot -= rot;
            transform.Rotate(Vector3.right, -rot);
        }

        //Clamp
        if (totalRot >= targetRot)
        {
            totalRot = targetRot;
        }
        else if (totalRot <= 0.0f)
        {
            totalRot = 0.0f;
        }

        //Reverse the rotation
        if (totalRot >= targetRot || totalRot <= 0.0f)
        {
            rotatingForward = !rotatingForward;
        }
    }
}
