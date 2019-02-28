using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Script that handles all of the Egg's actions during the game.
/// </summary>
public class Egg : MonoBehaviour {

    public float torque;
    public MenuManager menuManager;

    private Rigidbody rb;
    private ParticleSystem pSystem;

    private bool isHit;

    public bool IsHit
    {
        get { return isHit; }
        set { isHit = value; }
    }

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        pSystem = gameObject.GetComponent<ParticleSystem>();

        ChangeActiveTexture();
        ChangeParticleColor();
    }
	
	// Update is called once per frame
	void Update () {
        if (isHit && pSystem.isStopped && !GameInfo.instance.Paused && !GameInfo.instance.GameOver)
        {
            GameInfo.instance.GameOver = true;
            menuManager.toggleGameOver();
        }

        if (GameInfo.instance.Paused)
        {
            if (pSystem.isPlaying)
            {
                pSystem.Pause();
            }
        }
        else
        {
            if (pSystem.isPaused)
            {
                pSystem.Play();
                pSystem.Stop();
            }
        }
	}

    // Update for physics calls
    void FixedUpdate()
    {
        if (!isHit && !GameInfo.instance.Paused)
        {
            ApplyRotationalForce();
        }
        else if (GameInfo.instance.Paused)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }
    }

    /// <summary>
    /// Explodes the egg when it has hit an obstacle.
    /// </summary>
    public void Explode()
    {
        isHit = true;
        pSystem.Play();

        //Make sure the egg is invisible
        gameObject.GetComponent<MeshRenderer>().enabled = false;

        //Make sure the egg is no longer rotating (so the particles won't rotate too)
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
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
