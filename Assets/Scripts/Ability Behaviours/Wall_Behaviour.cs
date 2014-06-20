using UnityEngine;
using System.Collections;

public class Wall_Behaviour : MonoBehaviour {
	public float maxHealth = 1f;
	public float health;
	private bool isWhole = true;
	public GameObject playerID;

	public void onCast (float duration, float maxHp, float angle) {
		Invoke ("killMe",duration);
		maxHealth = maxHp;
		health = maxHealth;
		transform.rotation =
			Quaternion.Slerp (transform.rotation,
			                  Quaternion.Euler (0, 0, angle),
			                  100 * Time.deltaTime);

	}

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
	
	}

	void killMe(){
		Destroy (gameObject);
	}
}
