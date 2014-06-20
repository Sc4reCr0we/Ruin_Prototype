using UnityEngine;
using System.Collections;

public class InstantiateGame : MonoBehaviour {
	public int numberOfPlayers = 1;
	public GameObject player1;
	public GameObject player2;



	// Use this for initialization
	void Start () 
	{
		player1.active = true;
		if(numberOfPlayers >= 2)
			player2.active = true;

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(player1.GetComponent<HealthScript>().health <= 0 || player2.GetComponent<HealthScript>().health <= 0)
		{
			Application.LoadLevel(0);
		}
	}
}
