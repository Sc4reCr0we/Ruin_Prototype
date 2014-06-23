using UnityEngine;
using System.Collections;

public class setSprite : MonoBehaviour {
	public GameObject playerID;
	public string button;

	// Use this for initialization
	void Start () {
		if(button == "QKey")
			gameObject.GetComponent<UI2DSprite> ().sprite2D = playerID.GetComponent<slotManager> ().Q_slot.iconSprite;

		if(button == "EKey")
			gameObject.GetComponent<UI2DSprite> ().sprite2D = playerID.GetComponent<slotManager> ().E_slot.iconSprite;

		if(button == "RKey")
			gameObject.GetComponent<UI2DSprite> ().sprite2D = playerID.GetComponent<slotManager> ().R_slot.iconSprite;

		if(button == "SpaceKey")
			gameObject.GetComponent<UI2DSprite> ().sprite2D = playerID.GetComponent<slotManager> ().Spc_slot.iconSprite;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
