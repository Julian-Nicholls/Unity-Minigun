using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

	public int density;
	public int width;
	public float rotationCap;
	public float minDistance;

	public int numOfStages;
	public GameObject[] obstacles;

	public EnemySpawner enemySpawner;
	//used to spawn obstacles in a circle

	// Use this for initialization
	void Start () {

		for (int x = 0; x < numOfStages * density; x++) {

			Vector3 position = enemySpawner.randomPointOnCircle (transform.position, Random.Range (minDistance, width));

			GameObject obstacle = Instantiate (
              obstacles [Random.Range (0, obstacles.Length)],
              position,
              new Quaternion (
                  0,
                  0,
                  0,
                  0
              ),
              transform
          );

			obstacle.transform.localScale = new Vector3 (
				Random.Range (8, 10),
				Random.Range (15, 20),
				Random.Range (8, 10)
			);

			obstacle.transform.eulerAngles = new Vector3 (
				Random.Range(rotationCap, -rotationCap),
				Random.Range (0, 360)
			);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
