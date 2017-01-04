using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	static GameOver instance;
	// Use this for initialization
	Bird_Movement bird;
	void Start () {
		GetComponent<SpriteRenderer>().enabled = false;
		instance = this;
		GameObject player_go = GameObject.FindGameObjectWithTag("Player");
		if(player_go == null){
			Debug.LogError("No Object with tag 'Player'");
		}
		bird = player_go.GetComponent<Bird_Movement>();
	}
	
	// Update is called once per frame
	void Update () {
		if(instance.bird.dead){
			GetComponent<SpriteRenderer>().enabled = true;
		}
	}
}
