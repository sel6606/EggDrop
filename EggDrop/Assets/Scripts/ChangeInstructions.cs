using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeInstructions : MonoBehaviour {

	// Use this for initialization
	void Start () {
        SetAppropriateInstructions();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// Changes how to play instructions if a system has a gyroscope
    /// or an accelerometer.
    /// </summary>
    private void SetAppropriateInstructions()
    {
        if (SystemInfo.supportsGyroscope)
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = "Rotate your Device to dodge obstacles.\r\n\r\nFall for as long as possible for a high score!";
        }
        else
        {
            gameObject.GetComponent<TextMeshProUGUI>().text = "Tilt your Device left and right to dodge obstacles.\r\n\r\nFall for as long as possible for a high score!";
        }
    }
}
