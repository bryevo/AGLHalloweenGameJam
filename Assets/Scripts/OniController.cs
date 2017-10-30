using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OniController : MonoBehaviour {


	public float speed = 5f;
	public Rigidbody2D player;
	Rigidbody2D rigid;
	// Use this for initialization
	void Start () {
		rigid = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 playerDir = player.velocity;
		float t = 1f;

		Vector3 displacement = (playerDir * t) + player.transform.position;
		Vector3 dir = displacement - transform.position;
		transform.position += dir.normalized * speed * Time.deltaTime;
	}
}
