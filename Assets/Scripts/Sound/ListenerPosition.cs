using UnityEngine;
using System.Collections;

public class ListenerPosition : MonoBehaviour {

	public Transform TargetCamera;
	public float ListenerHeight = +8;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		transform.position = TargetCamera.position + new Vector3(0,0, ListenerHeight);
	}
}
