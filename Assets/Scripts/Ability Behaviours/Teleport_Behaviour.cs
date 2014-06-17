using UnityEngine;
using System.Collections;

public class Teleport_Behaviour : MonoBehaviour {
	public GameObject playerID;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (playerID != null)
		{
			playerID.transform.position = gameObject.transform.position;
			Destroy(gameObject);
		}
	}
}
