using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	public Transform laser;
	public Transform cursor;
	public float offset;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
		RaycastHit hit;
		if (Physics.Raycast (transform.position, transform.forward, out hit, 200)) {
			cursor.gameObject.SetActive (true);
			cursor.position = hit.point - offset * transform.forward;
			cursor.rotation = hit.transform.rotation;
		} else {
			cursor.gameObject.SetActive (false);
		}


		if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
			Instantiate (laser, transform.position, transform.rotation);
		}
	}
}
