using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMove : MonoBehaviour {

    public float moveSpeed;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        gameObject.transform.transform.localPosition += new Vector3(0, moveSpeed * Time.deltaTime, 0);


        float distance = Vector3.Distance(transform.position, Camera.main.transform.position) - 0.5f;

        Color temp = gameObject.GetComponent<MeshRenderer>().material.color;
        temp.a = Mathf.Clamp01(1.0f - (1.0f / distance));

        if(temp.a == 0)
        {
            Destroy(gameObject);
        }
        gameObject.GetComponent<Renderer>().material.color = temp;
	}
}
