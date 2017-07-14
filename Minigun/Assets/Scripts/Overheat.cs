using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Overheat : MonoBehaviour {

	public float heatRate;
	public float coolRate;

	float heat;

	public GameObject foreground;
	public GameObject background;
	public ShootControlScript scs;

	float fgHeight;
	bool canShoot;

	public float overheatAnimationDelay;
	float overheatAnimationTimer;
	public Material fgMaterial;
	bool animationStage;

	// Use this for initialization
	void Start () {
		fgHeight = foreground.transform.localScale.y;
		canShoot = true;
		overheatAnimationTimer = 0;
		animationStage = true;
	}
	
	// Update is called once per frame
	void Update () {

		if (heat > 0) {
			heat = heat - coolRate * Time.deltaTime;
		}

		foreground.transform.localScale = 
			new Vector3 (
				heat,
				fgHeight,
				1
			);

		if (!canShoot && foreground.transform.localScale.x < background.transform.localScale.x / 2 ) {
			canShoot = true;
			scs.SendMessage ("changeCanFire");
			fgMaterial.color = Color.red;
		}

		overheatAnimationTimer = overheatAnimationTimer + Time.deltaTime;

		if (!canShoot) {
			overheatAnimationTimer = overheatAnimationTimer + Time.deltaTime;

			if (overheatAnimationTimer > overheatAnimationDelay) {
				overheatAnimationTimer = 0;

				if (animationStage) {
					fgMaterial.color = Color.black;
				} else {
					fgMaterial.color = Color.red;
				}
				animationStage = !animationStage;
			}
		}
	}

	public void shotFired(){
		heat = heat + heatRate;

		if (foreground.transform.localScale.x > background.transform.localScale.x ) {
			canShoot = false;
			scs.SendMessage ("changeCanFire");

		}
	}
}
