using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpinControlScript : MonoBehaviour {

	public Button leftButton;
	public Button rightButton;

	public Transform pivot;
	public GameObject fc;
	public float sensitivity; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		if (leftButton.GetComponent<ButtonListener>().isClicked ) {
			SpinLeft ();
		}

		if (rightButton.GetComponent<ButtonListener>().isClicked ) {
			SpinRight ();
		}
	}
		
	void SpinRight(){
		fc.transform.RotateAround (pivot.position, Vector3.up, sensitivity);
	}

	void SpinLeft(){
		fc.transform.RotateAround (pivot.position, Vector3.up, -sensitivity);
	}

	void spin(){

	}
}
