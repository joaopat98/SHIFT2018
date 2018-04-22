using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
	public Transform[] posts;
	public int num_posts;
	public int tot_posts;
	public float range_x, range_y, range_z;
	// Use this for initialization
	void Start ()
	{
		Vuforia.CameraDevice.Instance.SetFlashTorchMode (true);
		transform.position -= new Vector3 (range_x / 2, range_y / 2, 0);
		for (num_posts = 0; num_posts < tot_posts; num_posts++) {
			Instantiate (posts [Random.Range (0, posts.Length)], transform.position + new Vector3 (Random.value * range_x, Random.value * range_y, Random.value * range_z), Quaternion.Euler (Vector3.up * 180), transform);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void newPost ()
	{

		Instantiate (posts [Random.Range (0, posts.Length)], transform.position + new Vector3(Random.value * range_x,Random.value * range_y,Random.value * range_z),Quaternion.Euler(Vector3.up * 180),transform);
	}


}
