using UnityEngine;
using System.Collections;

public class Grenade_Behaviour : MonoBehaviour {
	public float range;
	public float movSpeed;
	public float time;
	public float damage;
	public float pushback;
	public float pushStack;
	public float timer;
	public Transform instance;
	
	private Vector2 dirTemp;
	private float angle;
	
	// Use this for initializationd
	void Start () {
		
	}
	
	void killMe(){
		instanceCreate ();
		SpecialEffectsHelper.Instance.Explosion(transform.position);
		Destroy (gameObject);
	}

	public void instanceCreate(){

		Debug.Log("instanceCreate");
		Vector3 currentPosition = transform.position;

		var grenadeID = Instantiate (instance, currentPosition, Quaternion.identity) as Transform ;
		grenadeID.GetComponent<GrenadeExplosion_Behaviour> ().setDestroyTimer (timer);
		grenadeID.GetComponent<GrenadeExplosion_Behaviour> ().damage = damage;
		grenadeID.GetComponent<GrenadeExplosion_Behaviour> ().pushStack = pushStack;
		grenadeID.GetComponent<GrenadeExplosion_Behaviour> ().pushback = pushback;
	} 
	
	// Update is called once per framee
	void Update () 
	{
		
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
	
	public void onCast (Vector3 grenadeDir, float angle,float range1, float time1) {
		float timeLeft;
		movSpeed = range1 / time1;
		Invoke ("killMe",time1);
		rigidbody2D.velocity = grenadeDir * movSpeed;
		transform.rotation =
			Quaternion.Slerp (transform.rotation,
			                  Quaternion.Euler (0, 0, angle),
			                  100 * Time.deltaTime);
	}

}
