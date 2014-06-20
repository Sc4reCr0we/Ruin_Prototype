using UnityEngine;
using System.Collections;

public class Reflect_Behaviour : MonoBehaviour {
	private GameObject myCaster;
	
	// Use this for initializationd
	void Start () {
		
	}
	
	void killMe(){
		Destroy (gameObject);
	}
	
	// Update is called once per framee
	void FixedUpdate () {

		if(myCaster!= null)
		gameObject.transform.position = myCaster.transform.position;
	}
	
	public void onCast (float duration, GameObject caster) {
		myCaster = caster;
		Invoke ("killMe",duration);
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other != null && other.gameObject.tag== "Ability" && other.gameObject != myCaster) {
			other.gameObject.rigidbody2D.velocity *= -1;
			other.gameObject.transform.rotation = Quaternion.Inverse(other.gameObject.transform.rotation);

		}
	}
}
