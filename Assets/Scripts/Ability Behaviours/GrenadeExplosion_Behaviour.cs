using UnityEngine;
using System.Collections;

public class GrenadeExplosion_Behaviour : MonoBehaviour {
	public float damage;
	public float pushback;
	public float pushStack;
	private float colliderRadius;
	
	
	// Use this for initialization
	void Start () {
		colliderRadius = gameObject.GetComponent<CircleCollider2D> ().radius;
		gameObject.GetComponentInChildren<GrenadeExplosion_child> ().pushback = pushback;
		gameObject.GetComponentInChildren<GrenadeExplosion_child> ().pushStack = pushStack;
		gameObject.GetComponentInChildren<GrenadeExplosion_child> ().damage = damage;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<CircleCollider2D>().radius = Mathf.Lerp (gameObject.GetComponent<CircleCollider2D>().radius,
		                                                                 0.5f, 2.5f * Time.deltaTime);

		if (gameObject.GetComponent<CircleCollider2D> ().radius >= 0.94f)
			gameObject.GetComponent<CircleCollider2D> ().enabled = false;
	}
	
	void OnTriggerEnter2D(Collider2D other){

		if (other != null && other.gameObject.tag== "Player") {
			gameObject.GetComponentInChildren<CircleCollider2D> ().enabled = true;
			SpecialEffectsHelper.Instance.Explosion(transform.position);
			//other.gameObject.GetComponent<PushbackScript> ().pushPlayer (other.contacts[0].point,pushback,pushStack,transform);
		}

		if (other != null && other.gameObject.tag== "Ability") {
			SpecialEffectsHelper.Instance.Explosion(transform.position);
			Destroy(other.gameObject);
		}
		
		if (other != null && other.gameObject.tag == "Destructable") {
			SpecialEffectsHelper.Instance.Explosion(transform.position);
			other.gameObject.GetComponent<HealthScriptDestruct>().setHealth(damage);
		}
	}
	
	public void setDestroyTimer(float time)
	{
		Invoke ("objectDestroy", time);
	}
	
	public void objectDestroy()
	{
		Destroy (gameObject);
	}
	
}
