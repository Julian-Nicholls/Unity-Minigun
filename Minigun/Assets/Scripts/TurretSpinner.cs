using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSpinner : MonoBehaviour {

	public Transform pivot;
	public float sensitivity; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.D)) {
			SpinRight ();
		}

		if (Input.GetKey (KeyCode.A)) {
			SpinLeft();
		}
	}

	void SpinRight(){
		transform.RotateAround (pivot.position, Vector3.up, sensitivity);
	}

	void SpinLeft(){
		transform.RotateAround (pivot.position, Vector3.up, -sensitivity);
	}
}
