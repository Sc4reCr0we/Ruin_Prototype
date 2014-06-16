using UnityEngine;
using System.Collections;

public class PushbackScript : MonoBehaviour {

	public float maxStack;
	public float minStack;
	public float pushStack;

	public void pushPlayer(Vector3 hitLocation, float pushback, float stackAdd,Transform self){
		float pushbackCalced;
		pushbackCalced = pushback + (pushback * pushStack);
		Vector2 dirr = self.position - transform.position;
		gameObject.GetComponent<PlayerMovement> ().setPushedback (pushbackCalced);
		rigidbody2D.velocity = Vector2.zero;
		rigidbody2D.angularVelocity = 0f;
		rigidbody2D.AddForce(-dirr.normalized*pushbackCalced,ForceMode2D.Impulse);
		addStack (stackAdd);
	}



	private void checkStack(){

		if (pushStack > maxStack) {
			pushStack = maxStack;
		}

		if (pushStack < minStack) {
			pushStack = minStack;
		}


	}

	private void addStack(float stackAdd){
		pushStack += stackAdd/100;
	}

	// Use this for initialization
	void Awake () {
		pushStack = 0f;
	}
	
	// Update is called once per frame
	void Update () {
		checkStack ();

	}
}
