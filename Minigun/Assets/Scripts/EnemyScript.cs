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
	bool balanced;
	Transform parentTransform;

	public float getUpSpeed;
	public float speed;
	public float minDistance;
	public GameObject minigun;

	public HealthKeeper healthKeeper;
	public ScoreKeeper scoreKeeper;

	// Use this for initialization
	void Start () {
		renderer = GetComponent<MeshRenderer> ();
		renderer.material = enemyMaterials [health];
		transform.LookAt (minigun.transform);
		scoreKeeper = FindObjectOfType<ScoreKeeper> ();
		healthKeeper = FindObjectOfType<HealthKeeper> ();

		parentTransform = GetComponentInParent<Transform> ();
	}
	
	// Update is called once per frame
	void Update () {
		elapsedTime = elapsedTime + Time.deltaTime;

		if (elapsedTime > strategyTimer) {
			strategy = Random.Range (0, strategies);
			parentTransform.LookAt (minigun.transform);
			elapsedTime = 0;
		}

		if (Vector3.Distance (parentTransform.position, minigun.transform.position) > minDistance) {
			
			if (strategy == 0) {
				// straight ahead

				parentTransform.Translate (Vector3.forward * Time.deltaTime * speed);
			}
			if (strategy == 1) {
				//wide flank


			}
			if (strategy == 2) {
				//narrow flank


			}
		}


		if (transform.up != Vector3.up) {
			
			var rot = Quaternion.FromToRotation (transform.up, Vector3.up);
			GetComponent<Rigidbody> ().AddTorque (new Vector3 (rot.x, rot.y, rot.z) * getUpSpeed);

		} else {
			
		}
	}

	void takeDamage(){
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

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Bullet") {
			takeDamage ();
			Destroy(collision.gameObject);
		}

		if (collision.gameObject.tag == "Player") {
			healthKeeper.SendMessage("takeDamage");	
		}
	}

}
