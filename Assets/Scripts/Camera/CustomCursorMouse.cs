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
		GUI.DrawTexture (new Rect(Input.mousePosition.x-cursorSizeX/2, (Screen.height-Input.mousePosition.y)-cursorSizeY/2, cursorSizeX, cursorSizeY),myCursor);
	}


}