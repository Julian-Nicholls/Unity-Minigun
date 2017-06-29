using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSpinner : MonoBehaviour {

	public int rpm;
	private float rps;
	private Vector3 eulerAngle;

	public BulletSpawner bulletSpawner;

	// Use this for initialization
	void Start () {
		rpm = bulletSpawner.rpm;
		rps = rpm / 60f;
	}
	
	// Update is called once per frame
	void Update () {
		
		transform.Rotate(Vector3.forward * Time.deltaTime * (rps * 360));
	}
}
