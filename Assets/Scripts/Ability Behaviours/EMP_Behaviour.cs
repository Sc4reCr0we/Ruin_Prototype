using UnityEngine;
using System.Collections;

public class EMP_Behaviour : MonoBehaviour {
	private float SilenceDuration;
	private float colliderRadius;
	private GameObject myCaster;


	// Use this for initialization
	void Start () {
		SpecialEffectsHelper.Instance.Emp(transform.position);
		colliderRadius = gameObject.GetComponent<CircleCollider2D> ().radius;
	}

	public void onCast(float duration, GameObject mycaster){
		SilenceDuration = duration;
		myCaster = mycaster;
	}
	// Update is called once per frame
	void Update () {
		gameObject.GetComponent<CircleCollider2D>().radius = Mathf.Lerp (gameObject.GetComponent<CircleCollider2D>().radius,
		                                                                 10f, 1f * Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D other){
		
		if (other != null && other.gameObject.tag== "Player" && other.gameObject != myCaster) {
			SpecialEffectsHelper.Instance.Ice(other.gameObject.transform.position);
			other.gameObject.GetComponent<stateController> ().setSilence (4f);
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
