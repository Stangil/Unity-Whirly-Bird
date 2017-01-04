using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	static int score = 0;
	static int highScore = 0;

	static Score instance;

	static public void AddPoint(){
	
		if(instance.bird.dead)
		return;
		score++;

		if(score > highScore) {
			highScore = score;
		}
	}

	Bird_Movement bird;

	void Start(){
		instance = this;
		GameObject player_go = GameObject.FindGameObjectWithTag("Player");
		if(player_go == null){
			Debug.LogError("No Object with tag 'Player'");
		}
		bird = player_go.GetComponent<Bird_Movement>();
		score = 0;
		highScore = PlayerPrefs.GetInt("highScore", 0);
	}

	void OnDestroy(){
		instance = null;
		PlayerPrefs.SetInt("highScore", highScore);
	}
	// Update is called once per frame
	void Update () {
		guiText.text = "Score: " + score + "\nHigh Score: " + highScore;
	}
}
