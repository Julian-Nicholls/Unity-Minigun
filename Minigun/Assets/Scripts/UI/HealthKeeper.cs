using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthKeeper : MonoBehaviour {

	public RectTransform healthBar;
	public int damagePerHit;
	int health;
	float xValueLerp;
	public int maxHealth;

	// Use this for initialization
	void Start () {
		health = maxHealth;
		xValueLerp = healthBar.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void takeDamage (){
		health = health - damagePerHit;

		healthBar.localScale = new Vector3(health / maxHealth, 0);
		healthBar.position = new Vector3(Mathf.Lerp (xValueLerp, 0, health / maxHealth), 0);

		Debug.Log ("Damaged");
	}
}
