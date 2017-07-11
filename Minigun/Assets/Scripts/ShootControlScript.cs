using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootControlScript : MonoBehaviour {

	public GameObject bulletPrefab;
	public GameObject bulletSpawner;
	public GameObject firingChamber;

	public Button shootButton;

	public int maxRPM;
	public float rpm;
	private float rps;
	private float timeSinceShot;

	public float bulletForce;
	public float bulletVarience;

	public float spinUpRate;
	public float spinDownRate;

	bool isClicked;
	ButtonListener bl;


	void Start(){
		bl = shootButton.GetComponent<ButtonListener>();
	}

	void FixedUpdate () {

		isClicked = bl.isClicked;

		rps = rpm / 60f;
		timeSinceShot = timeSinceShot + Time.fixedDeltaTime;

		if (isClicked && rpm < maxRPM) {
			rpm = rpm + Time.fixedDeltaTime * spinUpRate;
		} 

		else if (!isClicked && rpm > 0.01f) {
			rpm = rpm - Time.fixedDeltaTime * spinUpRate;
		}

		if (isClicked && timeSinceShot > (1 / rps) / 4) {
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
