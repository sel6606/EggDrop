using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to flip the obstacle to a new rotation.
/// </summary>
public class Flip : MonoBehaviour {

    private Quaternion startRot;
    private Quaternion targetRot;

    public float waitTime;

	// Use this for initialization
	void Start () {
        startRot = transform.rotation;
        targetRot = startRot * Quaternion.Euler(180.0f, 0.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update () {
        if (!GameInfo.instance.Paused)
        {
            ChangeRotation();
        }
	}

    /// <summary>
    /// Changes the obstacle's rotation after a set amount of time.
    /// </summary>
    private void ChangeRotation()
    {
        if (waitTime > 0.0f)
        {
            waitTime -= Time.deltaTime;

            if (waitTime <= 0.0f)
            {
                transform.rotation = targetRot;
            }
        }
    }
}
