using UnityEngine;
using System.Collections;

public class Scatter_Behaviour : MonoBehaviour {
	public float range;
	public float speed;
	public float damage;
	public float pushback;
	public float pushStack;
	public float slowBy;
	public float slowTime;

	private Vector2 dirTemp;
	private float angle;
	
	// Use this for initializationd
	void Start () {
		
	}
	
	void killMe(){
		SpecialEffectsHelper.Instance.Ice(transform.position);
		Destroy (gameObject);
	}
	
	// Update is called once per framee
	void Update () {

		if(rigidbody2D.velocity != Vector2.zero)
		{
			dirTemp = rigidbody2D.velocity;
			dirTemp.Normalize ();
			angle = Mathf.Atan2 (dirTemp.y, dirTemp.x) * Mathf.Rad2Deg;
			
			gameObject.transform.rotation =
				Quaternion.Slerp (transform.rotation,
				                  Quaternion.Euler (0, 0, angle),
				                  100f * Time.deltaTime);
		}
		
	}
	
	public void onCast (Vector3 abilityDir, float speed1, float angle,float range1) {
		float timeLeft;
		timeLeft = range1 / speed1;
		Invoke ("killMe",timeLeft);
		rigidbody2D.velocity = abilityDir * speed1;
		transform.rotation =
			Quaternion.Slerp (transform.rotation,
			                  Quaternion.Euler (0, 0, angle),
			                  100 * Time.deltaTime);
	}
	
	void OnCollisionEnter2D(Collision2D other){
		
		if (other != null && other.gameObject.tag== "Player") {
			SpecialEffectsHelper.Instance.Ice(transform.position);
			other.gameObject.GetComponent<HealthScript> ().setHealth (damage);
			//other.gameObject.GetComponent<PushbackScript> ().pushPlayer (other.contacts[0].point,pushback,pushStack,transform);
			other.gameObject.GetComponent<PlayerMovement>().slowDown(slowBy,slowTime);
			
			Destroy (gameObject);
		}
		if (other != null && other.gameObject.tag== "Ability") {
			SpecialEffectsHelper.Instance.Ice(transform.position);
			Destroy (other.gameObject);
			Destroy (gameObject);
		}
		
		if (other != null && other.gameObject.tag == "Destructable") {
			SpecialEffectsHelper.Instance.Ice(transform.position);
			other.gameObject.GetComponent<HealthScriptDestruct>().setHealth(damage);
			Destroy (gameObject);
		}
	}
}
