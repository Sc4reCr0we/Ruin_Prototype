using UnityEngine;
using System.Collections;

public class GrenadeExplosion_child : MonoBehaviour {

	public float pushback;
	public float pushStack;
	public float damage;

	void OnCollisionEnter2D(Collision2D other){
		
		if (other != null && other.gameObject.tag== "Player") {
			other.gameObject.GetComponent<HealthScript> ().setHealth (damage);
			other.gameObject.GetComponent<PushbackScript> ().pushPlayer (other.contacts[0].point,pushback,pushStack,transform);
		}
	}


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
