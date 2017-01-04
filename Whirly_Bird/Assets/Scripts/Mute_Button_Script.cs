using UnityEngine;
using System.Collections;

public class Mute_Button_Script : MonoBehaviour {
	public bool muteToggle = false;

	public Texture2D muteImage = null;
	
	void OnGUI(){
		muteToggle = GUI.Toggle(new Rect(10, 10, Screen.width/5, Screen.height/5), muteToggle, "Mute");
		//muteImage = GUI.Toggle(new Rect(10, 10, Screen.width/5, Screen.height/5) muteImage);
		if(muteToggle == false){
			AudioListener.volume = 1;
		}
		else if(muteToggle == true){
			AudioListener.volume = 0;
		}
	}
}
