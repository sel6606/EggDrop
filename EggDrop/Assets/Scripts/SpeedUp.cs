using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour {

    public float maxSpeed;
    public float minSpawnRate;
    public float interval;
    public float speedMultiplier;
    public float spawnRateMultiplier;

    private float timer;
    private bool atMax;

	// Use this for initialization
	void Start () {
        timer = interval;
        atMax = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!atMax && !GameInfo.instance.Paused && !GameInfo.instance.GameOver)
        {
            IncreaseSpeed();
        }
	}

    private void IncreaseSpeed()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            //Reset timer
            timer = interval;

            //Increase speed
            GameInfo.instance.MoveSpeed *= speedMultiplier;

            //Increase spawn rate (decrese value to make it faster)
            GameInfo.instance.SpawnRate *= spawnRateMultiplier;

            //Clamp
            if (GameInfo.instance.SpawnRate < minSpawnRate)
            {
                GameInfo.instance.SpawnRate = minSpawnRate;
            }

            //Clamp
            if (GameInfo.instance.MoveSpeed > maxSpeed)
            {
                atMax = true;

                GameInfo.instance.MoveSpeed = maxSpeed;
            }
        }
    }
}
