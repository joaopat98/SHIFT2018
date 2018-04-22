using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostBehaviour : MonoBehaviour {
	public float size_range;
	public float speed;
	private GameControl player;
	private float init_scale;
	private bool expanding;
	private Generator manager;

	// Use this for initialization
	void Start () {
		player = GameObject.Find("ARCamera").GetComponent<GameControl> ();
		init_scale = transform.localScale.x;
		transform.localScale = transform.localScale + (Vector3.one * size_range * Random.Range (-1, 1));
		expanding = true;
		manager = transform.parent.GetComponent<Generator> ();
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Laser") {
			Destroy (col.gameObject);
			Delete ();
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (expanding) {
			transform.localScale += Vector3.one * speed * Time.deltaTime;
			if (transform.localScale.x > init_scale + size_range)
				expanding = false;
		} else {
			transform.localScale -= Vector3.one * speed * Time.deltaTime;
			if (transform.localScale.x < init_scale - size_range)
				expanding = true;
		}
	}

	void Delete(){
		manager.newPost ();
		player.AddHit ();
		player.UpdateHealth (1);
		Destroy (gameObject);
	}
}
