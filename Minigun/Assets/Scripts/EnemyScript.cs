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
	bool gravity = false;
	Transform parentTransform;

	public float getUpSpeed;
	public float restandHeight;
	public float speed;
	public float minDistance;
	public GameObject minigun;
	public GameObject capsule;

	public HealthKeeper healthKeeper;
	public ScoreKeeper scoreKeeper;
	public Hover hover;
	Rigidbody rb;

	bool coroutineRunning;
	bool fallOrFly;

	public float hoverMultiplier;

	// Use this for initialization
	void Start () {
		renderer = capsule.GetComponent<MeshRenderer> ();
		renderer.material = enemyMaterials [health];
		transform.LookAt (minigun.transform);
		scoreKeeper = FindObjectOfType<ScoreKeeper> ();
		healthKeeper = FindObjectOfType<HealthKeeper> ();
		rb = GetComponent<Rigidbody> ();




	}
	
	// Update is called once per frame
	void FixedUpdate () {

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
			
			//rb.isKinematic = false;
			Destroy(collision.gameObject);
			takeDamage ();

			if (!coroutineRunning) {
				StartCoroutine (bulletCoroutine ());
			}
		}

		if (collision.gameObject.tag == "Player") {
			healthKeeper.SendMessage("takeDamage");	
		}
	}

	IEnumerator bulletCoroutine(){
		coroutineRunning = true;
		if (Random.value > 0.5) {
			fallOrFly = true;
		} else {
			fallOrFly = false;
		}

		hover.changeMode ();

		yield return new WaitForSeconds (getUpSpeed);
		rb.useGravity = false;

		Debug.Log ("Coroutine executed");

		//rb.isKinematic = true;

		//setPosAndRot ();

		coroutineRunning = false;
		StopCoroutine (bulletCoroutine());
	}

	void setPosAndRot(){
		var rot = Quaternion.FromToRotation (transform.up, Vector3.up);
		transform.SetPositionAndRotation(transform.position + new Vector3(0, restandHeight, -2f), rot);
	}

}
