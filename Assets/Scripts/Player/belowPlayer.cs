using UnityEngine;
using System.Collections;

public class belowPlayer : MonoBehaviour {
	public GameObject playerObject;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (playerObject != null)
			transform.position = playerObject.transform.position;
	}
}
