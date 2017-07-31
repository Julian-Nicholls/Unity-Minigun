using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

	int health;
	public Material[] enemyMaterials;
	MeshRenderer renderer;

	Transform parentTransform;

	public GameObject minigun;
	public GameObject capsule;

	public ScoreKeeper scoreKeeper;


	public EnemyMovement enemyMovement;

	// Use this for initialization
	void Start () {
		renderer = capsule.GetComponent<MeshRenderer> ();
		renderer.material = enemyMaterials [health];
		transform.LookAt (minigun.transform);
		scoreKeeper = FindObjectOfType<ScoreKeeper> ();
		enemyMovement = GetComponent<EnemyMovement> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

	}

	public void takeDamage(){
		health--;

		if (health < 0) {
			Destroy (gameObject);
			scoreKeeper.SendMessage ("incrementScore");
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
