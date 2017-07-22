using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour {

	public Text textGUI;
	int scoreThisRound;
	int highScore;
	int waveLength;

	// Use this for initialization
	void Start () {
		scoreThisRound = 0;
		waveLength = PlayerPrefs.GetInt ("numOfEnemies");
		textGUI.text = scoreThisRound.ToString("000") + " / " + waveLength.ToString("000");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void incrementScore(){
		scoreThisRound++;
		textGUI.text = scoreThisRound.ToString("000") + " / " + waveLength.ToString("000");
	}
}
