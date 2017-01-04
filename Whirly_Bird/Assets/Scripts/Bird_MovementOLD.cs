using UnityEngine;
using System.Collections;

public class Bird_MovementOLD : MonoBehaviour {

	Vector3 velocity = Vector3.zero;
	public Vector3 gravity;
	public Vector3 flapVelocity;
	public float maxSpeed = 5f;
	public float forwardSpeed = 3f;

	bool didFlap = false;

	// Use this for initialization
	void Start () {
	
	}
	// Do Graphic & Input updates here
	void Update() {
		if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
			didFlap = true;
		}
	}
	// Do physics engine updates here
	void FixedUpdate () {
		velocity.x = forwardSpeed;
		velocity += gravity * Time.deltaTime;

		if(didFlap == true){
			didFlap = false;
			if(velocity.y < 0)
				velocity.y = 0;

			velocity += flapVelocity;

		}

		velocity = Vector3.ClampMagnitude(velocity, maxSpeed);

		transform.position += velocity * Time.deltaTime;
		//setting angle according to verticle velocity

		float angle = 0;
		if(velocity.y < 0){
			angle = Mathf.Lerp(0, -45, -velocity.y / maxSpeed);
        }

		transform.rotation = Quaternion.Euler(0, 0, angle);

	}
}
