using UnityEngine;
using System.Collections;

public class playbackSpeed : MonoBehaviour {
	public float speed = 1;

	// Use this for initialization
	void Start () {
	particleSystem.playbackSpeed = speed;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
