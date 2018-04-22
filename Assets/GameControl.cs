using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {
	public int max_health;
	public int health;
	public int hits;
	public int hit_limit;
	public Transform admin;
	public float range_x;
	public LikeSet like_bar;
	public HateSet hate_bar;
	// Use this for initialization
	void Start () {
		health = 0;
		like_bar.SetSize (health, max_health);
		hate_bar.SetSize (health, max_health);
	}

	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Laser") {
			Destroy (col.gameObject);
			UpdateHealth (-1);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void UpdateHealth(int num){
		health += num;
		if (health > 0) {
			like_bar.SetSize (health, max_health);
			hate_bar.SetSize (0, max_health);
		} else {
			hate_bar.SetSize (Mathf.Abs (health), max_health);
			like_bar.SetSize (0, max_health);
		}
	}

	public void AddHit(){
		hits++;
		if (hits == hit_limit) {
			hits = 0;
			Instantiate (admin, new Vector3 (Random.Range (-1f, 1f) * range_x, 300, 40), Quaternion.identity);
		}
	}
}
