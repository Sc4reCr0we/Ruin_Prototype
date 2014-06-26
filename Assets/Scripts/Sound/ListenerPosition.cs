using UnityEngine;
using System.Collections;

public class ListenerPosition : MonoBehaviour {

	public Transform TargetPlayer;
	public Transform TargetCamera;
	public float ListenerHeight = +8;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(TargetPlayer != null)
			transform.position = TargetPlayer.position + new Vector3(0,0, ListenerHeight);

		if(TargetCamera != null)
			transform.rotation = TargetCamera.rotation;
	}
}
