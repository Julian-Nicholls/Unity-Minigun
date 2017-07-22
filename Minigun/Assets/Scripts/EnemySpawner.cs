using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject minigun;
	public GameObject enemyPrefab;

	public float circleRadius;
	public float spawnRate;
	public int spawnTotal;
	float elapsedTime;
	int totalSpawned = 0;

	// Use this for initialization
	void Start () {


	}

	public Vector3 randomPointOnCircle(Vector3 centre, float radius){

		Vector3 position;
		float angle = Random.value * 360;

		position.x = centre.x + radius * Mathf.Sin(angle * Mathf.Deg2Rad);
		position.y = centre.y;
		position.z = centre.z + radius * Mathf.Cos(angle * Mathf.Deg2Rad);

		return position;

	}
	
	// Update is called once per frame
	void Update () {

		elapsedTime = elapsedTime + Time.deltaTime;

		int waveLength = PlayerPrefs.GetInt ("numOfEnemies");

		if (elapsedTime > spawnRate && totalSpawned < waveLength) {

			elapsedTime = 0;

			GameObject enemy = Instantiate (
				enemyPrefab, 
				randomPointOnCircle(minigun.transform.position, circleRadius),
				new Quaternion()
			) as GameObject;

			EnemyScript es = enemy.GetComponentInChildren<EnemyScript> ();
			es.setHealth(Random.Range(1, es.enemyMaterials.Length));
			es.setMinigun(minigun);

			totalSpawned++;

		}

	}
}
