using UnityEngine;
using System.Collections;

public class ListenerPosition : MonoBehaviour {

	public Transform target;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = target.position + new Vector3(0,0, +8);
	}
}
