using UnityEngine;
using System.Collections;

public class Bullets : MonoBehaviour {

	void OnCollisionEnter2D ( Collision2D collider ) {
		Destroy( gameObject );
	}
}
