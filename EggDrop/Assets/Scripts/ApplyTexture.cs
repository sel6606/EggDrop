using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to change the texture of the egg at game start.
/// </summary>
public class ApplyTexture : MonoBehaviour {

	// Use this for initialization
	void Start () {
        ChangeActiveTexture();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Changes the texture of the egg according to which one was selected.
    /// </summary>
    private void ChangeActiveTexture()
    {
        gameObject.GetComponent<Renderer>().material.mainTexture = GameInfo.instance.CurrTexture;
    }
}
