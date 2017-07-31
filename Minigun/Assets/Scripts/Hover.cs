using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour {

	public float distanceFromGround;
	public int mode;

	public Rigidbody rb;
	bool fallOrFly;
	Vector3 pointOfInterest;
	float minDistance;
	EnemyScript es;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		pointOfInterest = GameObject.Find ("Minigun").transform.position;

		es = GetComponent<EnemyScript> ();
		minDistance = es.minDistance;

		mode = 1;
	}
	
	// Update is called once per frame
	void FixedUpdate () {



		if (Vector3.Distance (transform.position, pointOfInterest) > minDistance) {

			//transform.Translate (Vector3.forward * Time.fixedDeltaTime * speed);
			if (rb.useGravity && fallOrFly) {


			} else if (rb.useGravity && !fallOrFly) {


			} else if (!rb.useGravity) {

				if (transform.position.y < 0) {

				}
				if (transform.position.y > 0) {
					
				}


				//set rotation upright

			}

			if (mode == 0) {
				// straight ahead


			}
			if (mode == 1) {
				//wide flank


			}
			if (mode == 2) {
				//narrow flank

				//rot.eulerAngles * getUpSpeed * Time.deltaTime
			}
		} else {

		}
	}

	public void changeMode(){
		if (mode == 1) {

			mode = 2;

			rb.constraints = RigidbodyConstraints.None;


		} else {
			
			mode = 1;

			rb.constraints = RigidbodyConstraints.FreezePositionY;
			transform.SetPositionAndRotation (
				(transform.position - new Vector3(0, transform.position.y, 0)),
				Quaternion.FromToRotation(transform.up, Vector3.up)
			);
		}
	}
}
