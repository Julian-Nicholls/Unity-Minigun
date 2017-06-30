using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigunScript : MonoBehaviour {

	public GameObject bulletPrefab;
	public GameObject bulletSpawner;
	public GameObject firingChamber;

	public int maxRPM;
	public float rpm;
	private float rps;
	private float timeSinceShot;

	public float bulletForce;
	public float bulletVarience;

	public float spinUpRate;
	public float spinDownRate;

	// Use this for initialization
	void Start () {
		
	}
	
	void FixedUpdate () {

		rps = rpm / 60f;
		timeSinceShot = timeSinceShot + Time.fixedDeltaTime;

		if (Input.GetKey (KeyCode.Space) && rpm < maxRPM) {
			rpm = rpm + Time.fixedDeltaTime * spinUpRate;
		} 

		if (!Input.GetKey (KeyCode.Space) && rpm > 0.01f) {
			rpm = rpm - Time.fixedDeltaTime * spinUpRate;
		}

		if (Input.GetKey (KeyCode.Space) && timeSinceShot > (1 / rps) / 4) {
			timeSinceShot = 0;
			Fire ();
		}
	}

	void Fire(){
		GameObject bullet = Instantiate (bulletPrefab, bulletSpawner.transform);

		bullet.GetComponent<Rigidbody> ().AddForce (bulletForce * (firingChamber.transform.forward + 
			new Vector3(Random.Range(-bulletVarience, bulletVarience),
				Random.Range(-bulletVarience, bulletVarience),
				Random.Range(-bulletVarience, bulletVarience))));

		//bullet.transform.forward
	}
}
