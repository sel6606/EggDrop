using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject[] branchPrefabs;
    public float spawnRate;
    public GameObject ball;
    public Material border;

    private float timer;
    private float currentObstacleSpeed = 7.0f;
    public float borderSpeed = 0.175f;

    private const float speedConversion = -0.175f / 7.0f;

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

        borderSpeed = currentObstacleSpeed * speedConversion;

        Vector2 offset = new Vector2(0, borderSpeed * Time.time);

        border.mainTextureOffset = offset;
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

        currentObstacleSpeed = newObstacle.GetComponent<ObstacleMove>().moveSpeed;
    }

    public void RotateWorld(float degreesToRotate)
    {
        gameObject.transform.Rotate(0, degreesToRotate, 0);
    }
}
