using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class that handles using the phone's accelerometer to rotate the world.
/// </summary>
public class UseAccelerometer : MonoBehaviour {

    public List<GameObject> obstacles;

    private Quaternion calibration;

    // Use this for initialization
    void Start () {
        //Use the Gyroscope if a device has it, since rotation works better than the Accelerometer
        if (SystemInfo.supportsGyroscope)
        {
            Input.gyro.enabled = true;
        }
        else
        {
            CalibrateAccelerometer();
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (!GameInfo.instance.Paused)
        {
            RotateObstacles();
        }
	}

    /// <summary>
    /// Stores variables necessary to re-calibrate accelerometer input according
    /// to the device's initial orientation.
    /// </summary>
    private void CalibrateAccelerometer()
    {
        //Get the device's initial movement data
        Vector3 initialAcceleration = Input.acceleration;

        //Get the rotation from this acceleration
        Quaternion initialRotation = Quaternion.FromToRotation(-Vector3.forward, initialAcceleration);

        //Store the calibrated data
        calibration = Quaternion.Inverse(initialRotation);
    }

    /// <summary>
    /// Adjusts the acceleration data based on the calibration/
    /// </summary>
    /// <param name="acceleration">acceleration vector from the Accelerometer</param>
    /// <returns>the adjusted acceleration</returns>
    private Vector3 AdjustedMovement(Vector3 acceleration)
    {
        return calibration * acceleration;
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
                Vector3 calibratedAcceleration = AdjustedMovement(Input.acceleration);
                obstacles[i].transform.Rotate(0.0f, calibratedAcceleration.x, 0.0f);
            }
        }

        #if UNITY_EDITOR
        //FOR DEBUG
        for (int i = 0; i < obstacles.Count; i++)
        {
            if (Input.GetKey(KeyCode.RightArrow))
            {
                obstacles[i].transform.Rotate(0.0f, -1.0f * Time.deltaTime * 80.0f, 0.0f);
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                obstacles[i].transform.Rotate(0.0f, 1.0f * Time.deltaTime * 80.0f, 0.0f);
            }
        }
        #endif
    }
}
