using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	public Text textGUI;
	int scoreThisRound;
	int highScore;

	// Use this for initialization
	void Start () {
		scoreThisRound = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void incrementScore(){
		scoreThisRound++;
		textGUI.text = scoreThisRound.ToString ("X");
	}
}
