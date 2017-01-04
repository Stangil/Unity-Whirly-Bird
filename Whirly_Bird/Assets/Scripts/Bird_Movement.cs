using UnityEngine;
using System.Collections;

public class Bird_Movement : MonoBehaviour {

//	Vector3 velocity = Vector3.zero;
	public float flapSpeed = 1200f;
	public float forwardSpeed = 10f;
	public AudioSource explosionSound;
	public float crashVolume = .2f;
	bool didFlap = false;
	float deathCooldown;

	Animator animator;

	public bool dead = false;

	public bool godMode = false;

	// Use this for initialization
	void Start () {
		animator = transform.GetComponentInChildren<Animator>();

		explosionSound = (AudioSource)gameObject.AddComponent ("AudioSource");
		AudioClip crashSound;
		crashSound = (AudioClip)Resources.Load ("SFX/explosion_large_with_glass_debris_002");
		explosionSound.clip = crashSound;
		explosionSound.loop = false;
		explosionSound.volume = crashVolume;
	}

	// Do Graphic & Input updates here
	void Update() {
		if(dead){
			deathCooldown -= Time.deltaTime;

			if(deathCooldown <= 0){
				explosionSound.Stop();
				if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){

				Application.LoadLevel(0);
				}
			}
		}
		else{
		if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
			didFlap = true;
			}
		}
	}
	// Do physics engine updates here
	void FixedUpdate () {

		if (dead)

			return;

		rigidbody2D.AddForce( Vector2.right * forwardSpeed );

		if(didFlap){
		rigidbody2D.AddForce( Vector2.up * flapSpeed);
//			animator.SetTrigger("DoFlap");

			didFlap = false;
		}
		float angle = 0;
		if (rigidbody2D.velocity.y > 0) {
			transform.rotation = Quaternion.Euler (0, 0, 0);
				}
		else {
			angle = Mathf.Lerp (0, -60, -rigidbody2D.velocity.y / 25f);
			transform.rotation = Quaternion.Euler (0, 0, angle);
			}
		}

	void OnCollisionEnter2D(Collision2D collision) {
		if (godMode)
			return;
		animator.SetTrigger("Death");

		explosionSound.Play();

		dead = true;

		deathCooldown = 0.5f;
	}

}
