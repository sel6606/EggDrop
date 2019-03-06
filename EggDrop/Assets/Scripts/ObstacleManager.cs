﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject[] branchPrefabs;
    public GameObject ball;

    private float timer;

	// Use this for initialization
	void Start ()
    {
        timer = GameInfo.instance.SpawnRate;
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = GameInfo.instance.SpawnRate;
            SpawnObstacle();
        }
	}

    public void SpawnObstacle()
    {
        float spawnRotation = Random.Range(0, 359);
        int obstacleSeed = Random.Range(0, branchPrefabs.Length + 5);
        if(obstacleSeed >= branchPrefabs.Length)
        {
            obstacleSeed = 0;
        }

        GameObject newObstacle = Instantiate(branchPrefabs[obstacleSeed], Vector3.zero, Quaternion.AngleAxis(spawnRotation, Vector3.up), transform);

        //Need to rotate the branches to have them look appropriate in-game
        if (newObstacle.CompareTag("Branch1"))
        {
            newObstacle.transform.Rotate(Vector3.right, 60.0f);
        }
        else if (newObstacle.CompareTag("Branch2"))
        {
            newObstacle.transform.Rotate(Vector3.right, 90.0f);
        }
    }

    public void RotateWorld(float degreesToRotate)
    {
        gameObject.transform.Rotate(0, degreesToRotate, 0);
    }
}
