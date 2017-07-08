using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject minigun;
	public GameObject enemyPrefab;
	public Transform[] spawnPoints;

	public float spawnRate;
	public int spawnTotal;
	float elapsedTime;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		elapsedTime = elapsedTime + Time.deltaTime;

		if (elapsedTime > spawnRate) {

			elapsedTime = 0;

			GameObject enemy = Instantiate (
				enemyPrefab, 
				spawnPoints [Random.Range (0, spawnPoints.Length)].position,
				new Quaternion()
			) as GameObject;

			EnemyScript es = enemy.GetComponent<EnemyScript> ();
			es.setHealth(Random.Range(1, es.enemyMaterials.Length));
			es.setMinigun(minigun);

		}

	}
}
