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
        //Use the Gyroscope if a device has it, since rotation works better than the Accelerometer
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
        }
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
            //Use Gyroscope over Accelerometer if it is supported
            if (Input.gyro.enabled)
            {
                obstacles[i].transform.Rotate(0.0f, Input.gyro.rotationRateUnbiased.z, 0.0f);
            }

            //Default to Accelerometer
            else
            {
                obstacles[i].transform.Rotate(0.0f, Input.acceleration.y, 0.0f);
            }
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
