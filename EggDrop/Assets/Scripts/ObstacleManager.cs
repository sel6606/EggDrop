using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject branchPrefab;
    public float spawnRate;
    public GameObject ball;

    private float timer;

	// Use this for initialization
	void Start ()
    {
        timer = spawnRate;
	}
	
	// Update is called once per frame
	void Update ()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            timer = spawnRate;
            SpawnObstacle();
        }
	}

    public void SpawnObstacle()
    {
        float spawnRotation = Random.Range(0, 359);
        GameObject newObstacle = Instantiate(branchPrefab, Vector3.zero, Quaternion.AngleAxis(spawnRotation, Vector3.up), transform);

        //Need to rotate the branches by 90 degrees to have them turned correctly
        newObstacle.transform.Rotate(Vector3.forward, 90.0f);
    }

    public void RotateWorld(float degreesToRotate)
    {
        gameObject.transform.Rotate(0, degreesToRotate, 0);
    }
}
