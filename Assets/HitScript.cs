using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitScript : MonoBehaviour {
	public float speed = 1;
	private float time;

	// Use this for initialization
	void Start () {
		time = 0;
	}



	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.forward * speed * Time.deltaTime);
		time += Time.deltaTime;
		if (time > 4)
			Destroy (gameObject);
	}
}
