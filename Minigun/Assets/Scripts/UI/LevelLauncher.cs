using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLauncher : MonoBehaviour {

	int level;
	int numOfEnemies;
	int numOfSpawners;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void launchScene(){

		PlayerPrefs.SetInt ("level", level);
		PlayerPrefs.SetInt ("numOfEnemies", numOfEnemies);
		PlayerPrefs.SetInt ("numOfSpawners", numOfSpawners);

		SceneManager.LoadScene (level);
	}
}
