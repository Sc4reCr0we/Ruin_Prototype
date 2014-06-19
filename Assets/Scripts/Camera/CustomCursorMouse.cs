using UnityEngine;
using System.Collections;

public class CustomCursorMouse : MonoBehaviour {

	public Texture2D myCursor;
	public int cursorSizeX = 32;  // set to width of your cursor texture
	public int cursorSizeY = 32;  // set to height of your cursor texture
	
	void Start(){
		Screen.showCursor = false;
	}

	void OnGUI()
	{
		GUI.DrawTexture (new Rect(Input.mousePosition.x, (Screen.height-Input.mousePosition.y), cursorSizeX, cursorSizeY),myCursor);
	}


}