﻿using UnityEngine;
using System.Collections;

public class CameraTracksPlayer : MonoBehaviour {
	Transform player;

	float offsetx;

	// Use this for initialization
	void Start () {
		GameObject player_go = GameObject.FindGameObjectWithTag("Player");
		if(player_go == null){
			Debug.LogError("Couldn't find objrct with tag 'Player' !!!");
			return;
		}
		player = player_go.transform;

		offsetx = transform.position.x - player.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		if(player != null){
			Vector3 pos = transform.position;
		pos.x = player.position.x + offsetx;
		transform.position = pos;
		}
	}
}
