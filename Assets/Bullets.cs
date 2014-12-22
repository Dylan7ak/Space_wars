using UnityEngine;
using System.Collections;

public class Bullets : MonoBehaviour {

	void OnCollisionEnter2D ( Collision2D collider ) {

		if (collider.gameObject.name.Contains ( "Alien1" ) ) {
				Enemy enemy = collider.gameObject.GetComponent< Enemy > ();
				enemy.Kill ();
		}
		Destroy( gameObject );
	}
}
