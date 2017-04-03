using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	private Ball ball;
	public bool autoPlay = false;
	
	public float mouseSensitivity = Mathf.Clamp(0.6f, 0f, 1f);
	// Use this for initialization
	void Start () {
		ball = Object.FindObjectOfType<Ball> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		if(autoPlay && Ball.ballLaunched){
			FollowBall ();
		}
		else {
			FollowMouse ();
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		ball.canBoost = true;
	}

	void FollowMouse(){
		Vector3 paddlePos = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);
		float mousePos = Input.mousePosition.x - 400;

		paddlePos.x = Mathf.Clamp (mousePos * mouseSensitivity / 30, -6f, 6f);			
		this.transform.position = paddlePos;
	}

	void FollowBall(){
		Vector3 paddlePos = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);
		float ballPos = ball.transform.position.x;
		paddlePos.x = ballPos;
	
		this.transform.position = new Vector3 (ballPos, this.transform.position.y, this.transform.position.z);

	}
}
