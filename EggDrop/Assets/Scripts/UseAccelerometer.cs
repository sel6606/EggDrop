using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that handles using the phone's accelerometer to rotate the world.
/// </summary>
public class UseAccelerometer : MonoBehaviour {

    public List<GameObject> obstacles;
    public float rotationSpeed;

    // Use this for initialization
    void Start () {
        Input.gyro.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
        RotateObstacles();
	}

    /// <summary>
    /// Uses the accelerometer to rotate all obstacles
    /// </summary>
    private void RotateObstacles()
    {
        //FOR MOBILE
        for (int i = 0; i < obstacles.Count; i++)
        {
            //Accelerometer
            //obstacles[i].transform.Rotate(0.0f, Input.acceleration.y, 0.0f);

            //Gyroscope
            obstacles[i].transform.Rotate(0.0f, Input.gyro.rotationRateUnbiased.z, 0.0f);
        }

        #if UNITY_EDITOR
        //FOR DEBUG
        for (int i = 0; i < obstacles.Count; i++)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                obstacles[i].transform.Rotate(0.0f, -1.0f * Time.deltaTime * rotationSpeed, 0.0f);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                obstacles[i].transform.Rotate(0.0f, 1.0f * Time.deltaTime * rotationSpeed, 0.0f);
            }
        }
        #endif
    }
}
