using UnityEngine;
using System.Collections;

public class Ship : MonoBehaviour {
	/* Declaration of a public variable of float type called 
	accelertion. WebCamFlags will UserAuthorization this Touch accelerate the script. */
	public float acceleration;

	/* Declaration of a public variable float type called
	acceleration. We will use this to slow down our ship. */
	public float drag;

	/* Declaration of a public variable float type called
	maxSpeed. We will use this to limit the speed of the ship. */
	public float maxSpeed;

	/* Declaration of a private variable Vector2 type called
	velocity. We will use this to control the velocity of our ship. */
	private Vector2 velocity;

	void OnCollisionEnter2D ( Collision2D collider ) {

		//need to fix this so game don't lag on death.
		if (collider.gameObject.name.Contains ( "Alien1" ) ) {
			Destroy ( gameObject );
		}
	}

	// On every frame while the game is running.
	void Update () {

		// If we are holding the D key down, execute code inside the brackets.
		if (Input.GetKey (KeyCode.D)) {
				velocity.x += Time.fixedDeltaTime * acceleration;
		} 

		// Otherwise if we are holding the A key down, execute code inside the brackets.
		else if (Input.GetKey (KeyCode.A)) {
			velocity.x -= Time.fixedDeltaTime * acceleration;
		} 

		// Otherwise if the x velocity is not equal to zero, execute code inside the brackets.
		else if (velocity.x != 0) {

			/* Detect if the ship is traveling left or right. This statement
			 * is using the ternary operator, which is similar to a if statement. */
			int value = velocity.x > 0 ? -1 : 1;

			/* Reduce the X velocity  of the ship by the result of fixed multiplied
			by the diretion of the ship multiplied by our drag variable. */
			velocity.x += Time.fixedDeltaTime * value * drag;

			/* Get the absolute value of the X velocity to get a speed
			and check if that speed is less then one. If the speed is less 
			then one, set X velocity to zero. */
			if (Mathf.Abs (velocity.x) < 1) {

				// Set X velocity to zero.
				velocity.x = 0;
			}

			/*
		 	If the ship is moving right
			Then slow down to the left.
			Otherwise if the ship moving left.
			Then slow down to the right.
			*/

		}

		// If we are holding the W key down, execute code inside the brackets.
		if (Input.GetKey (KeyCode.W)) {
			velocity.y += Time.fixedDeltaTime * acceleration;
		}

		// Otherwise if we are holding the S key down, execute code inside the brackets.
		else if (Input.GetKey (KeyCode.S)) {
			velocity.y -= Time.fixedDeltaTime * acceleration;
		} 

		// Otherwise if the Y velocity is not equal to zero, execute code inside the brackets.
		else if (velocity.y != 0) {

			/* Detect if the ship is traveling up or down. This statement
			is using the ternary operator, which is similar to a if statment. */
			int value = velocity.y > 0 ? -1 : 1;

			/* Reduce the Y velocity of the ship by the result of fixed multiplied
			by the direction of the ship multiplied by our drag variable. */
			velocity.y += Time.fixedDeltaTime * value * drag;

			/* Get the absolute value of the Y velocity to get a speed
			and check if that speed is less then one. If the speed is less 
			then one, set Y velocity to zero. */ 
			if (Mathf.Abs (velocity.y) < 1) {

				// Set Y velocity to zero.
				velocity.y = 0;
			}
		}

		/* Clamp the speed of the ship using this function: Mathf.Clamp( value, min max );
		this will clamp the X and Y velocity to our negative and positive variable
		maxSpeed. */
		velocity.x = Mathf.Clamp( velocity.x, -maxSpeed, maxSpeed );
		velocity.y = Mathf.Clamp( velocity.y, -maxSpeed, maxSpeed );
	}
	/* This function is similar to Update. Update will look as
	computer will let it. FixedUpdate is tied to a specific timing for 
	physics calculation. */
	void FixedUpdate () {

		/* Finally after all of our volocity calculation above, we set
		the velocity of the 2D physics rigidbody attached to our ship. */
		rigidbody2D.velocity = velocity;

		/* The following code below prevents the shipe frame from
		resetting its direction when the velocity is zero. */

		/* Create a new temporary variable of the Vector2 type, then 
		set it to the current direction of the ship. */
		Vector2 direction = transform.up;

		/* If X Velocity is not equeal to 0 then set the X direction
		to the calculated X velocity. */
		if (velocity.x != 0) {
				direction.x = velocity.x;
				}

		/* If Y Velocity is not equeal to 0 then set the X direction
		to the calculated Y velocity. */
		if ( velocity.y != 0 ) {
				direction.y = velocity.y;
			}
		// Prevent the ship from spinning when the ship collides with a wall.
		rigidbody2D.angularVelocity = 0;

		// Set the direction of the ship to our calculed direction
		transform.up = direction;
	}
}
