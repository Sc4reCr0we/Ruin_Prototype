using UnityEngine;
using System.Collections;

public class stateController : MonoBehaviour {

	public bool isSilenced;
	public bool isSlowed;
	public bool isStunned;

	public void setSilence(bool silenced,float duration){
		isSilenced = silenced;
		Invoke ("removeSilence", duration);
	}

	public void setSlow (bool slowed, float duration){
		isSlowed = slowed;
		Invoke ("removeSlow", duration);
	}

	public void setStun(bool stunned, float duration){
		isStunned = stunned;
		Invoke ("removeStun", duration);
	}

	public void removeStun(){
		isStunned = false;
	}

	public void removeSilence(){
		isSilenced = false;
	}

	public void removeSlow(){
		isSlowed = false;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(gameObject!=null){

			if(isSilenced)
				gameObject.GetComponent<slotManager>().setCanCast(false);
			else if (!isSilenced)
				gameObject.GetComponent<slotManager>().setCanCast(true);




		}
	}
}
