﻿using UnityEngine;
using System.Collections;

public class BGMover : MonoBehaviour {

	Rigidbody2D player;
	void Start (){

	GameObject player_go = GameObject.FindGameObjectWithTag("Player");
	if(player_go == null){
		Debug.LogError("Couldn't find objrct with tag 'Player' !!!");
		return;
	}
	player = player_go.rigidbody2D;
	

	}
	void FixedUpdate (){
		float vel = player.velocity.x * 0.5f;

		transform.position = transform.position + Vector3.right * vel * Time.deltaTime;
	}
}
