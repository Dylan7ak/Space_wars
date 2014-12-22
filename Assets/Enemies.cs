using UnityEngine;
using System.Collections;

public class Enemies : MonoBehaviour {

	public GameObject enemyPrefab;
	public float spawnRate;
	private float spawnTime;
	
	void Update () {
		spawnTime -= Time.deltaTime;

		if (spawnTime <= 0) {

			Spawn();

			spawnTime = spawnRate;
		}
	}

	private void Spawn () {
		GameObject newEnemy = Instantiate ( enemyPrefab ) as GameObject;
		newEnemy.transform.position = RandomPosition();
	}

	private Vector2 RandomPosition () {
		float x = Random.Range( -10, 10 );
		float y = Random.Range( -6, 6 );

		return new Vector2( x, y );

}











}