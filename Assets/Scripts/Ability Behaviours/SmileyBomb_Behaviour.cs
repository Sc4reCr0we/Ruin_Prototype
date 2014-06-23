using UnityEngine;
using System.Collections;

public class SmileyBomb_Behaviour : MonoBehaviour {
	public float timer;
	public float damage;
	public float pushback;
	public float pushStack;
	public GameObject smileyExpl;
	public float explTimer;

	// Use this for initializationd
	void Start () {
		
	}
	
	void killMe(){
		GameObject explosionID = Instantiate (smileyExpl, transform.position, Quaternion.identity) as GameObject;
		explosionID.GetComponent<SmileyBombExplosion_Behaviour> ().damage = damage;
		explosionID.GetComponent<SmileyBombExplosion_Behaviour> ().pushStack = pushStack;
		explosionID.GetComponent<SmileyBombExplosion_Behaviour> ().pushback = pushback;
		explosionID.GetComponent<SmileyBombExplosion_Behaviour> ().setDestroyTimer(explTimer);
		Destroy (gameObject);
	}
	
	// Update is called once per framee
	void Update () {
		
	}
	
	public void onCast (float timer) {
		float timeLeft = timer;
		Invoke ("killMe",timeLeft);
	}
	
	/*void OnCollisionEnter2D(Collision2D other){
		
		if (other != null && other.gameObject.tag== "Player") {
			SpecialEffectsHelper.Instance.Explosion(transform.position);
			other.gameObject.GetComponent<HealthScript> ().setHealth (damage);
			other.gameObject.GetComponent<PushbackScript> ().pushPlayer (other.contacts[0].point,pushback,pushStack,transform);
			
			Destroy (gameObject);
		}
		if (other != null && other.gameObject.tag== "Ability") {
			SpecialEffectsHelper.Instance.Explosion(transform.position);
			Destroy(other.gameObject);
			Destroy (gameObject);
		}
		
		if (other != null && other.gameObject.tag == "Destructable") {
			SpecialEffectsHelper.Instance.Explosion(transform.position);
			other.gameObject.GetComponent<HealthScriptDestruct>().setHealth(damage);
			Destroy (gameObject);
		}
	}*/
}
