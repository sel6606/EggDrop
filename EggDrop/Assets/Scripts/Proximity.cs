using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proximity : MonoBehaviour
{
    public float fadeStartDistance = 8;
    public float fadeCompleteDistance = 3;
    public Transform transformToCheck;
    private float distance = 0f;
    private Material branchMat;
    private bool fadeStarted;

    public Material transparent;

	// Use this for initialization
	void Start ()
    {
        branchMat = GetComponent<Renderer>().material;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Color col = branchMat.color;
        distance = Mathf.Abs(Camera.main.transform.position.y - transformToCheck.position.y);
        if (distance > fadeStartDistance)
        {
            col.a = 1f;
        }
        else if (distance > fadeCompleteDistance)
        {
            if (!fadeStarted)
            {
                branchMat = transparent;
                GetComponent<Renderer>().material = branchMat;

                fadeStarted = true;
            }
            float newAlpha = (distance - fadeCompleteDistance) / (fadeStartDistance - fadeCompleteDistance);
            col.a = newAlpha;
        }
        else
        {
            col.a = 0f;
        }

        branchMat.color = col;
    }
}
