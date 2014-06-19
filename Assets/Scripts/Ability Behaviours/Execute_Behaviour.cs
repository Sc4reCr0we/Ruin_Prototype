using UnityEngine;
using System.Collections;

public class Execute_Behaviour : MonoBehaviour {
	public float range;
	public float speed;
	public float damage;
	public float pushback;
	public float pushStack;
	public GameObject playerID = null;
	public float instakillPercentage;
	public float angle;
	
	// Use this for initializationd
	void Start () {
		
	}
	
	void killMe(){
		SpecialEffectsHelper.Instance.Explosion(transform.position);
		Destroy (gameObject);
	}
	
	// Update is called once per framee
	void Update () 
	{
		if(playerID != null)
		{
			playerID.transform.position = gameObject.transform.position;
			playerID.transform.rotation = gameObject.transform.rotation;
		}
	}
	
	public void onCast (Vector3 fireballDir, float speed1, float angle,float range1) {
		float timeLeft;
		timeLeft = range1 / speed1;
		Invoke ("killMe",timeLeft);
		rigidbody2D.velocity = fireballDir * speed1;
		transform.rotation =
			Quaternion.Slerp (transform.rotation,
			                  Quaternion.Euler (0, 0, angle),
			                  100 * Time.deltaTime);
	}
	
	void OnCollisionEnter2D(Collision2D other){
		
		if (other != null && other.gameObject.tag== "Player" && other.gameObject != playerID) {
			SpecialEffectsHelper.Instance.Explosion(transform.position);
			if(other.gameObject.GetComponent<HealthScript> ().health < other.gameObject.GetComponent<HealthScript> ().maxHealth * (instakillPercentage))
			{
				other.gameObject.GetComponent<HealthScript> ().health = 0;
			}
			else
				other.gameObject.GetComponent<HealthScript> ().setHealth (damage);

			other.gameObject.GetComponent<PushbackScript> ().pushPlayer (other.contacts[0].point,pushback,pushStack,transform);
			
			Destroy (gameObject);
		}
		/* if (other != null && other.gameObject.tag== "Ability") {
			SpecialEffectsHelper.Instance.Explosion(transform.position);
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
		*/
		if (other != null && other.gameObject.tag == "Destructable") {
			SpecialEffectsHelper.Instance.Explosion(transform.position);
			other.gameObject.GetComponent<HealthScriptDestruct>().setHealth(damage);
			Destroy (gameObject);
		}
	}
}
