using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public EnemyScript enemyScript;
	Rigidbody rb;

	bool coroutineRunning;
	public HealthKeeper healthKeeper;
	public float movementSpeed;

	public float timerLimit;
	float timer;

	// Use this for initialization
	void Start () {
		enemyScript = GetComponent<EnemyScript> ();
		rb = GetComponent<Rigidbody> ();
		coroutineRunning = false;

		healthKeeper = FindObjectOfType<HealthKeeper> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//move towards player OR collapse / fall / ragdoll when hit by boolet

		if (rb.isKinematic) {


			timer = timer + Time.deltaTime;
			if (timer > timerLimit) {
				timer = 0;
				transform.LookAt (enemyScript.minigun.transform.position);
			}

			transform.Translate (Vector3.forward * movementSpeed * Time.fixedDeltaTime);
			
		} else {


		}
	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "Bullet") {

			rb.isKinematic = false;
			rb.AddExplosionForce (1000f, collision.contacts [0].point, 100f);
			Debug.Log ("point: " + collision.contacts [0].point);

			Destroy(collision.gameObject);
			enemyScript.takeDamage ();

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

		} else {

		}

		yield return new WaitForSeconds (1);

		setPosAndRot ();
		rb.isKinematic = true;

		coroutineRunning = false;
		StopCoroutine (bulletCoroutine());
	}

	void setPosAndRot(){

		rb.r

		var rot = Quaternion.FromToRotation (transform.up, Vector3.up);
		transform.SetPositionAndRotation(
			new Vector3(transform.position.x, 0, transform.position.z), rot);
	}
}
