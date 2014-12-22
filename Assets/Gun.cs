using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	// Referencing our bullet prefab, prefabs are like blueprints.
	public Transform bulletPrefab;

	// Current time between bullets.
	public float fireRate;

	// Number of bullets fired.
	private float fireTime;

	// While the game is running on every frame.
	public int bulletCount;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//if (Input.GetKey ( KeyCode.Space ) ) {

		/* Converts mouse pixel position to world
		position using camra. */
		Vector2 mouseWorld = Camera.main.ScreenToWorldPoint( Input.mousePosition );

		// Calculates direction from gun to mouse position.
		Vector2 direction = mouseWorld - ( Vector2 )transform.position;

		// Sets the direction of the gun to our calculated direction.
		transform.up = direction;


		// We will use a timer to set the fire rate.
		fireTime -= Time.deltaTime;

		// If time is less then zero, fire a new bullet.
		if (fireTime <= 0) {


			/* Using our bullet prefab, spawn a new bullet
			and store it in a temporary variable. */
			GameObject newBullet = Instantiate (bulletPrefab.gameObject) as GameObject;

			/* If the bullet is divisible by 2, return 
			0.1f, if its not divisible by 2, return 0.1 */
			float flip = bulletCount % 2 == 0 ? -0.1f : 0.1f;

			/* Create a new 2D Vector2 coordinate. This
			coordinate is realtive to the ship. */
			Vector2 local = new Vector2( flip, 1 );

			/*  Convert our relative local coordinate to 
			world coordinates using the TransformPoint
			function. */
			Vector2 world = transform.TransformPoint( local );

			/* Set the new bullet's position to our calculated
			world position relative to the ship. */
			newBullet.transform.position = world;

			/* Since this gun is the chiled of our ship. We can
			 access our ship's transform by calling 
			 transform.parent. */
			newBullet.rigidbody2D.velocity = transform.parent.rigidbody2D.velocity + ( Vector2 )transform.up * 10;

			/* Set the direction of the bullet, to the direction
			of the gun. Which is the direction of the ship. */
			newBullet.transform.up = transform.up;

			// Reset our timer.
			fireTime = fireRate;

			// Increment bullet count by one.
			bulletCount++;
		}
	}
}
