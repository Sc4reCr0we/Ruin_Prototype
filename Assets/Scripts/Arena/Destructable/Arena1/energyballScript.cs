using UnityEngine;
using System.Collections;

public class energyballScript : MonoBehaviour {
	public float generators = 4f;

	private void killEnergyball(){
		Destroy (gameObject);
	}

	public void generatorDown(float number){
		generators -= 1;
	}
	
	// Use this for initialization
	void Start () {
	
	}

	// Update is called once per frame
	void Update () {
	
		if (generators <= 0f) {
				if(!IsInvoking("killEnergyball")){
				Invoke("killEnergyball",1f);
				}
				
		}

	}

	void OnCollisionEnter2D (Collision2D other){
		if (other != null) {

			if (other.gameObject.tag== "Ability") {
				other.gameObject.rigidbody2D.velocity *= -1;
			}

		}
	}
}
