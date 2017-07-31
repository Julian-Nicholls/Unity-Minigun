using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

	public EnemyScript enemyScript;
	Rigidbody rb;

	public bool coroutineRunning;
	public HealthKeeper healthKeeper;
	public float movementSpeed;

	public float timerLimit;
	float timer;
	public bool setPosAndRot = false;
	Quaternion upRotation;
	float animationSteps = 0f;
	public float minDistance;

	// Use this for initialization
	void Start () {
		enemyScript = GetComponent<EnemyScript> ();
		rb = GetComponent<Rigidbody> ();
		coroutineRunning = false;

		healthKeeper = FindObjectOfType<HealthKeeper> ();
		upRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		//move towards player OR collapse / fall / ragdoll when hit by boolet OR animate standing up
		
		if (setPosAndRot) {

			animationSteps = animationSteps + Time.fixedDeltaTime / 2;
			transform.rotation = Quaternion.Lerp (transform.rotation, upRotation, animationSteps);

			if(transform.rotation.eulerAngles.x == 0 && transform.rotation.eulerAngles.z == 0){
				setPosAndRot = false;
				animationSteps = 0;
			}

		} else {

			if (rb.isKinematic) {

				if (transform.position.y > 0) {
					transform.Translate (Vector3.down * Time.fixedDeltaTime * 2);
				}

				timer = timer + Time.deltaTime;
				if (timer > timerLimit) {
					timer = 0;
					transform.LookAt (enemyScript.minigun.transform.position);
				}

				if (Vector3.Distance (transform.position, enemyScript.minigun.transform.position) > minDistance) {
					transform.Translate (Vector3.forward * movementSpeed * Time.fixedDeltaTime);
				}


			} else {
				
			}
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

		yield return new WaitForSeconds (3);

		setPosAndRot = true;
		rb.isKinematic = true;

		coroutineRunning = false;
		StopCoroutine (bulletCoroutine());
	}
		
}
