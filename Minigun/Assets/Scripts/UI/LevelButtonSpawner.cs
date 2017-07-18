using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelButtonSpawner : MonoBehaviour {

	public int numOfActs;
	public int numOfLevels;

	public int startX;
	public int startY;

	public int Xpadding;
	public int Ypadding;
	public int width;

	public Button buttonPrefab;

	Vector3 position;
	LevelLauncher levelLauncher;
	Text buttonText;
	int buttons = 0;

	// Use this for initialization
	void Start () {

		for (int y = 0; y < numOfLevels; y++) {
			for (int x = 0; x < numOfActs; x++) {

				position.x = startX + ((width + Xpadding) * x);
				position.y = startY - ((width + Ypadding) * y);

				Button button = Instantiate (buttonPrefab) as Button;
				button.transform.SetParent (this.transform);
				button.GetComponent<RectTransform> ().anchoredPosition = position;

				button.name = "LevelLauncher" + buttons;
				buttonText = button.GetComponentInChildren<Text> ();
				buttonText.text = buttons.ToString("X");

				levelLauncher = button.GetComponent<LevelLauncher> ();
				levelLauncher.setup (buttons, 10, 10);

				buttons++;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
