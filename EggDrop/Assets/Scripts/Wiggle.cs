using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to have the obstacles wiggle.
/// </summary>
public class Wiggle : MonoBehaviour {

    public float rotationSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        PerformWiggle();
	}

    /// <summary>
    /// Wiggles the obstacle.
    /// </summary>
    private void PerformWiggle()
    {
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
