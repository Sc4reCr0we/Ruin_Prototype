using UnityEngine;
using System.Collections;

public class CustomCursorController : MonoBehaviour {
	
	public Texture2D myCursor;
	public int cursorSizeX = 32;  // set to width of your cursor texture
	public int cursorSizeY = 32;  // set to height of your cursor texture
	
	public Transform controllerCursor_player2;
	
	void Start(){
		Screen.showCursor = false;
	}
	
	void OnGUI(){
		GUI.DrawTexture (new Rect(controllerCursor_player2.position.x-cursorSizeX/2, (Screen.height-controllerCursor_player2.position.y)-cursorSizeY/2, cursorSizeX, cursorSizeY),myCursor);
	}
	
	void Update()
	{	
		Vector3 temp = controllerCursor_player2.position;
		if (temp.x < gameObject.transform.position.x - camera.pixelWidth/65)
		{
			temp.x = gameObject.transform.position.x - camera.pixelWidth/65;
			controllerCursor_player2.position = temp;
		}

		if (temp.x > gameObject.transform.position.x + camera.pixelWidth/65)
		{
			temp.x = gameObject.transform.position.x + camera.pixelWidth/65;
			controllerCursor_player2.position = temp;
		}

		if (temp.y < gameObject.transform.position.y - camera.pixelHeight/65)
		{
			temp.y = gameObject.transform.position.y - camera.pixelHeight/65;
			controllerCursor_player2.position = temp;
		}

		if (temp.y > gameObject.transform.position.y + camera.pixelHeight/65)
		{
			temp.y = gameObject.transform.position.y + camera.pixelHeight/65;
			controllerCursor_player2.position = temp;
		}


	}
}