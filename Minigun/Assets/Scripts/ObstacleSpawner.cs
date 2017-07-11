using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

	public int density;
	public int width;
	public float rotationCap;

	public int numOfStages;
	public GameObject[] obstacles;

	// Use this for initialization
	void Start () {

		for (int x = 0; x < numOfStages*density; x++) {

			Vector3 position = new Vector3 (
				Random.Range (-width, width),
				0,
				Random.Range (-width, width)
			);

			GameObject obstacle = Instantiate (
				obstacles [Random.Range (0, obstacles.Length)],
				position,
				new Quaternion (
				  	Random.Range (0, rotationCap),
				  	Random.Range (0, rotationCap),
				  	Random.Range (0, rotationCap),
					0
				),
				transform
			);

			obstacle.transform.localScale = new Vector3 (
				Random.Range(8, 10),
				Random.Range(15, 20),
				Random.Range(8, 10)
			);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
