using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOrientation : MonoBehaviour {

	private Quaternion initialRotation, gyroInitialRotation;


	// Use this for initialization
	void Start () {
		Input.gyro.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.LookRotation(-Vector3.up) * GyroToUnity(Input.gyro.attitude);
	}

	private static Quaternion GyroToUnity(Quaternion q)
	{
		return new Quaternion(q.x, q.y, -q.z, -q.w);
	}
}
