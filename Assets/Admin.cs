using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Admin : MonoBehaviour
{
	public int max_health;
	public int health;
	public WidthSetter healthBar;
	public Transform laser;
	public GameObject player;
	private int state = 0;
	public float init_y, init_x, entry_speed, speed, range, dev, offset;
	private float counter;
	

	// Use this for initialization
	void Start ()
	{

		player = GameObject.Find("ARCamera");
		counter = 0;
		health = max_health;
		healthBar.SetSize (health, max_health);
		range += Random.Range (-1f, 1f) * dev;
	}

	void OnTriggerEnter (Collider col)
	{
		if (col.gameObject.tag == "Laser") {
			Destroy (col.gameObject);
			health--;
			if (health == 0) {
				GameControl gc = player.GetComponent<GameControl> ();
				gc.UpdateHealth (3);
				Destroy (gameObject);
			}
			healthBar.SetSize (health, max_health);
		}
	}

	// Update is called once per frame
	void Update ()
	{
		transform.LookAt (2 * transform.position - player.transform.position);
		switch (state) {
		case 0:
			transform.Translate (Vector3.down * entry_speed, Space.World);
			if (transform.position.y < init_y) {
				state = 1;
				init_x = transform.position.x;
			}
			break;
		case 1:
			transform.Translate (Vector3.down * speed, Space.World);
			if (transform.position.y < init_y - range)
				state = 2;
			break;
		case 2:
			transform.Translate (Vector3.right * speed, Space.World);
			if (transform.position.x > init_x + range)
				state = 3;
			break;
		case 3:
			transform.Translate (Vector3.up * speed, Space.World);
			if (transform.position.y > init_y)
				state = 4;
			break;
		case 4:
			transform.Translate (Vector3.left * speed, Space.World);
			if (transform.position.x < init_x)
				state = 1;
			break;
		}

		if (state != 0) {
			counter += Time.deltaTime;
			if (counter > 4) {
				Instantiate (laser, transform.position,	Quaternion.LookRotation (player.transform.position - transform.position + (Vector3.down * offset)));
				counter = 0;
			}
		}

	}
}
