using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script to constantly rotate the obstacles.
/// </summary>
public class RotateAround : MonoBehaviour {

    public float rotationSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        RotateObstacle();	
	}

    /// <summary>
    /// Rotates the obstacle.
    /// </summary>
    private void RotateObstacle()
    {
        float angle = rotationSpeed * Time.deltaTime;

        transform.Rotate(Vector3.right, angle);
    }
}
