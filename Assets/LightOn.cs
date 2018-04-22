using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightOn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Vuforia.CameraDevice camera = GetComponent<Vuforia.CameraDevice> ();
		camera.SetFlashTorchMode (true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
