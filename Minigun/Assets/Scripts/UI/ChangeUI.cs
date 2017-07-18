using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeUI : MonoBehaviour {

	public Canvas main;
	public Canvas level;

	// Use this for initialization
	void Start () {
		if (main.enabled == true && level.enabled == true) {
			level.enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void changeUp(){

		//Debug.Log ("executed");

		if (main.enabled == true) {
			main.enabled = false;
			level.enabled = true;
		} else {
			main.enabled = true;
			level.enabled = false;
		}
	}
}
