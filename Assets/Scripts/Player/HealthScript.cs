using UnityEngine;
using System.Collections;

public class HealthScript : MonoBehaviour {

	public float maxHealth;
	public float health;
	public bool isDead = false;

	public void setHealth (float value){
		health += value;
	}

	public float getHealth (){
		return health;
	}
	
	public bool CheckDead(){
		if (health <= 0f) {
			isDead = true;
		}
		return isDead;
	}

	private void checkmaxHealth(){
		if (health > 1000f) {
			health=1000f;
		}
	}

	// Use this for initialization
	void Awake () {
		health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		checkmaxHealth ();
		CheckDead ();
		if (isDead) {
			Debug.Log ("en spelare e död");
		}

	}
}
