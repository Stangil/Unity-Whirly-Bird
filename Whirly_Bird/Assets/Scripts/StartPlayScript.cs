using UnityEngine;
using System.Collections;

public class StartPlayScript : MonoBehaviour {
	
	public Texture2D buttonImage = null;
	
	void OnGUI(){
		if (GUI.Button(new Rect(Screen.width/3 , Screen.height/9, Screen.width/3, Screen.height/3), buttonImage))
		{
			Application.LoadLevel(1);
		}
	}
}
