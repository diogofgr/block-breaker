using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	private Ball ball;
	
	public float mouseSensitivity = Mathf.Clamp(0.6f, 0f, 1f);
	// Use this for initialization
	void Start () {
		ball = Object.FindObjectOfType<Ball> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		// this line is not even setting the initial paddle positio...
		Vector3 paddlePos = new Vector3 (this.transform.position.x, this.transform.position.y, this.transform.position.z);
		float mousePos = Input.mousePosition.x - 400;

//		print ("initial paddle pos: " + paddlePos.x);
//		print (mousePos);

		paddlePos.x = Mathf.Clamp (mousePos * mouseSensitivity / 30, -6f, 6f);

//		print ("new paddle pos: " + paddlePos.x);
		this.transform.position = paddlePos;
	}

	void OnCollisionEnter2D(Collision2D other){
		ball.canBoost = true;
	}
}
