using UnityEngine;
using System.Collections;

public class sortingLayer : MonoBehaviour {

	public string Layer = "Foreground"; 

	// Use this for initialization
	void Start () {
		particleSystem.renderer.sortingLayerName = Layer;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
