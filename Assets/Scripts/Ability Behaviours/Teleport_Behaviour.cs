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
			SpecialEffectsHelper.Instance.Teleport(playerID.transform.position);
			playerID.transform.position = gameObject.transform.position;
			SpecialEffectsHelper.Instance.Teleport(gameObject.transform.position);
			Destroy(gameObject);
		}
	}
}
