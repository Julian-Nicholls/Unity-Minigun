using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour {

	public GameObject bulletPrefab;

	public int rpm;
	private float rps;
	private float timeSinceShot;

	public float bulletForce;

	public float bulletVarience;

	// Use this for initialization
	void Start () {
		rps = rpm / 60f;
	}
	
	// Update is called once per frame
	void Update () {

		timeSinceShot = timeSinceShot + Time.deltaTime;

		if (timeSinceShot > (1 / rps) / 4) {
			timeSinceShot = 0;
			Fire ();
		}

	}

	void Fire(){
		GameObject bullet = Instantiate (bulletPrefab, transform);
		bullet.GetComponent<Rigidbody> ().AddForce (bulletForce * (transform.forward + 
			new Vector3(Random.Range(-bulletVarience, bulletVarience),
						Random.Range(-bulletVarience, bulletVarience),
						Random.Range(-bulletVarience, bulletVarience))));

		Debug.Log ("Bang!");



		//bullet.transform.forward
	}
}
