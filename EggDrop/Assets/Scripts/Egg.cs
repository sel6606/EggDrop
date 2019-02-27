using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that handles all of the Egg's actions during the game.
/// </summary>
public class Egg : MonoBehaviour {

    public float torque;

    private Rigidbody rb;
    private bool isHit;

    public bool IsHit
    {
        get { return isHit; }
        set { isHit = value; }
    }

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();

        ChangeActiveTexture();
        ChangeParticleColor();
    }
	
	// Update is called once per frame
	void Update () {
        if (isHit)
        {
            
        }
	}

    // Update for physics calls
    void FixedUpdate()
    {
        if (!isHit)
        {
            ApplyRotationalForce();
        }
    }

    /// <summary>
    /// Changes the texture of the egg according to which one was selected.
    /// </summary>
    private void ChangeActiveTexture()
    {
        gameObject.GetComponent<Renderer>().material.mainTexture = GameInfo.instance.CurrTexture;
    }

    /// <summary>
    /// Changes the color of the particle associated with the texture
    /// </summary>
    private void ChangeParticleColor()
    {
        ParticleSystem.MainModule pMain = gameObject.GetComponent<ParticleSystem>().main;
        pMain.startColor = GameInfo.instance.ParticleColor;
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
