﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleMove : MonoBehaviour {

    public float moveSpeed;

	// Use this for initialization
	void Start ()
    {
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!GameInfo.instance.Paused)
        {
            gameObject.transform.transform.localPosition += new Vector3(0, moveSpeed * Time.deltaTime, 0);


            float distance = Vector3.Distance(transform.position, Camera.main.transform.position);

            //Color temp = gameObject.GetComponent<MeshRenderer>().material.color;
            //temp.a = Mathf.Clamp01(1.0f - (1.0f / distance));

            if (distance <= 0.5)
            {
                Destroy(gameObject);
            }
            //gameObject.GetComponent<Renderer>().material.color = temp;
        }
	}

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!collision.gameObject.GetComponent<Egg>().IsHit)
            {
                GameInfo.instance.MoveSpeed = 0;
                collision.gameObject.GetComponent<Egg>().Explode();
            }
        }
    }
}
