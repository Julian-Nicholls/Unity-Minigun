using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ButtonListener : MonoBehaviour, IPointerDownHandler, IPointerUpHandler {

	public bool isClicked;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnPointerDown(PointerEventData ped){
		isClicked = true;
	}

	public void OnPointerUp(PointerEventData ped){
		isClicked = false;
	}
}
