using UnityEngine;
using System.Collections;

public class Gui_Button_Quit : MonoBehaviour {

	public Texture2D buttonImage = null;

	void OnGUI(){
		if (GUI.Button(new Rect(Screen.width/3 , Screen.height/2, Screen.width/3, Screen.height/3), buttonImage))
		{
			Application.Quit();
		}
	}
}
