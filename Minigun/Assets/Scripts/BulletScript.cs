using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

	public int lifetime;
	private float life;

	// Use this for initialization
	void Start () {
		life = 0;
	}
	
	// Update is called once per frame
	void Update () {

		life = life + Time.deltaTime;

		if (life > lifetime) {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter(Collision collision){
		if (collision.gameObject.tag == "EnemyCollider") {
			collision.gameObject.SendMessageUpwards ("takeDamage");
			Debug.Log ("collision!");
		}
	}
}
