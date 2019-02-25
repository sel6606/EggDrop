using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that handles all of the Egg's actions during the game.
/// </summary>
public class Egg : MonoBehaviour {

    public float torque;

    private Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();

        ChangeActiveTexture();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // Update for physics calls
    void FixedUpdate()
    {
        ApplyRotationalForce();
    }

    /// <summary>
    /// Changes the texture of the egg according to which one was selected.
    /// </summary>
    private void ChangeActiveTexture()
    {
        gameObject.GetComponent<Renderer>().material.mainTexture = GameInfo.instance.CurrTexture;
    }

    /// <summary>
    /// Rotates the egg to simulate it falling.
    /// </summary>
    private void ApplyRotationalForce()
    {
        float xRot = torque * Time.deltaTime;
        float yRot = xRot / 1.5f;
        float zRot = yRot;

        rb.AddTorque(xRot, yRot, zRot);
    }
}
