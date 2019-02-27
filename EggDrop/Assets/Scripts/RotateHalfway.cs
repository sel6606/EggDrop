using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script to constantly rotate the obstacle back and forth 180 degrees.
/// </summary>
public class RotateHalfway : MonoBehaviour {

    public float rotationSpeed;

    private Quaternion startRot;
    private Quaternion targetRot;

    public float time;
    private bool movingToTarget;

	// Use this for initialization
	void Start () {
        startRot = transform.rotation;
        targetRot = startRot * Quaternion.Euler(180.0f, 0.0f, 0.0f);
        movingToTarget = true;
	}
	
	// Update is called once per frame
	void Update () {
        RotateObstacle();
	}

    /// <summary>
    /// Rotates obstacle back and forth by 180 degrees from its start rotation.
    /// </summary>
    private void RotateObstacle()
    {
        time += Time.deltaTime;

        Mathf.Clamp(time, 0.0f, 1.0f);

        if (movingToTarget)
        {
            Quaternion.Slerp(startRot, targetRot, Time.deltaTime);
        }
        else
        {
            Quaternion.Slerp(targetRot, startRot, Time.deltaTime);
        }

        if (time >= 1.0f)
        {
            time = 0.0f;
            movingToTarget = !movingToTarget;
            transform.rotation = targetRot;
        }
    }
}
