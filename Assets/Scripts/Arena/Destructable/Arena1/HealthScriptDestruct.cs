using UnityEngine;
using System.Collections;

public class HealthScriptDestruct : MonoBehaviour {
	public float maxHealth = 1000f;
	public float health;
	private bool isWhole = true;


	public void setHealth(float value){
			health += value;
	}

	private void checkHealth(){
		if (health > maxHealth) {
			health=maxHealth;
		}
	}

	public float getHealth(){
		return health;
	}

	private void checkWhole(){
		if (health <= 0f) {
			isWhole=false;
		}
	}

	private void whenBroken(){
		if (!isWhole) {
			GetComponentInParent<energyballScript>().generatorDown(1f);
			Destroy (gameObject);
		}
	}                

	// Use this for initialization
	void Awake () {
		health = maxHealth;
	}
	
	// Update is called once per frame
	void Update () {
		checkHealth ();
		checkWhole ();
		whenBroken ();
		if (GetComponentInParent<ArenaStateController> ().getState ()) {
			isWhole=false;
		}
	
	}
}
