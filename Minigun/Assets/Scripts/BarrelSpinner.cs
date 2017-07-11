using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSpinner : MonoBehaviour {

	public float rpm;
	private float rps;
	private Vector3 eulerAngle;

	public ShootControlScript scs;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void FixedUpdate () {
		rpm = scs.rpm;
		rps = rpm / 60f;
		transform.Rotate(Vector3.forward * Time.fixedDeltaTime * (rps * 360));
	}
}
