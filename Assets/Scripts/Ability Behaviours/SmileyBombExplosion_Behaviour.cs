using UnityEngine;
using System.Collections;

public class SmileyBombExplosion_Behaviour : MonoBehaviour {
	public float damage;
	public float pushback;
	public float pushStack;
	private float colliderRadius;


	// Use this for initialization
	void Start () {
		colliderRadius = gameObject.GetComponent<CircleCollider2D> ().radius;
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<CircleCollider2D>().radius = Mathf.Lerp (gameObject.GetComponent<CircleCollider2D>().radius,
		                                                                 1.1f, 1.5f * Time.deltaTime);

		if (gameObject.GetComponent<CircleCollider2D> ().radius >= 0.94f)
						gameObject.GetComponent<CircleCollider2D> ().enabled = false;
	}

	void OnTriggerEnter2D(Collider2D other){
		
		if (other != null && other.gameObject.tag== "Player") {
			SpecialEffectsHelper.Instance.Explosion(transform.position);
			other.gameObject.GetComponent<HealthScript> ().setHealth (damage);
			Debug.Log("Player Hit");
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
