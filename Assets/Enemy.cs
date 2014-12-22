using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public float speed;

	public virtual void Kill () {
		Destroy( gameObject );
	}
}
