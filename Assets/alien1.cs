using UnityEngine;
using System.Collections;

public class alien1 : Enemy {

	public Transform target;

	void Start () {
		target = GameObject.Find ("Ship").transform;
	}
	
	void FixedUpdate () {
		Vector2 direction = ( target.position - transform.position ).normalized;
		rigidbody2D.velocity = direction * speed;
	}
}
