using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private Paddle paddle;
	private Vector3 ballToPaddleVector;
	private Vector2 currentVelocity;

	private bool ballLaunched;
	public bool canBoost;
	private float verticalBoost = 5f;

	// Use this for initialization
	void Start () {
		paddle = Object.FindObjectOfType<Paddle> ();

		ballLaunched = false;
		canBoost = false;
		ballToPaddleVector = this.transform.position - paddle.transform.position;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (!ballLaunched){
			this.transform.position = paddle.transform.position + ballToPaddleVector;

			if(Input.GetMouseButtonDown(0)){
				ballLaunched = true;
				canBoost = true;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(2f,9f);
			} 
		}
		else {
			// Give vertical canBoost when you click right mouse after the ball hits the paddle:
			if(Input.GetMouseButtonDown(1) && canBoost){
				canBoost = false;
				currentVelocity = this.GetComponent<Rigidbody2D> ().velocity;
				this.GetComponent<Rigidbody2D>().velocity = new Vector2(currentVelocity.x, currentVelocity.y + verticalBoost);
			} 
		}
		
	}

}
