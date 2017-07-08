using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	int health;
	public Material[] enemyMaterials;
	MeshRenderer renderer;

	public float strategyTimer;
	int strategies = 0;
	int strategy;
	float elapsedTime = 0;

	public float speed;
	public GameObject minigun;

	// Use this for initialization
	void Start () {
		renderer = GetComponentInChildren<MeshRenderer> ();
		renderer.material = enemyMaterials [health];
		transform.LookAt (minigun.transform);

	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime = elapsedTime + Time.deltaTime;

		if (elapsedTime > strategyTimer) {
			strategy = Random.Range (0, strategies);
			transform.LookAt (minigun.transform);
			elapsedTime = 0;
		}

		if (strategy == 0) {
			// straight ahead

			transform.Translate(Vector3.forward*Time.deltaTime*speed);
		}
		if (strategy == 1) {
			//wide flank


		}
		if (strategy == 2) {
			//narrow flank


		}

	}

	void takeDamage(){
		health--;

		if (health == -1) {
			Destroy (gameObject);
		} else {
			renderer.material = enemyMaterials [health];
		}
	}

	public void setHealth(int h){
		health = h;
	}

	public void setMinigun(GameObject mg){
		minigun = mg;
	}

}
