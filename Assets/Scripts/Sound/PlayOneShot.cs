using UnityEngine;
using System.Collections;

public class PlayOneShot : MonoBehaviour {

	public FMODAsset SoundToBePlayed = null;
	public bool PlayOnAwake = true;

	// Use this for initialization
	void Start () {

	if(PlayOnAwake)
			FMOD_StudioSystem.instance.PlayOneShot(SoundToBePlayed, transform.position);

	}
	

}
