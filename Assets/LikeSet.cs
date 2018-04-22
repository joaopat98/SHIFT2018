using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LikeSet : MonoBehaviour {
	public float max_scale;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}

	public void SetSize(int num, int divs){
		transform.localScale = new Vector3(max_scale / divs * num, transform.localScale.y, transform.localScale.z);
		transform.localPosition = new Vector3 (((max_scale / divs * num)/2), transform.localPosition.y, transform.localPosition.z);
	}
}
