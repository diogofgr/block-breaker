using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		levelManager = Object.FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D other) {
		StartCoroutine (GameOverAfterTime (1));
	}

	IEnumerator GameOverAfterTime(float time) {
		yield return new WaitForSeconds(time);
		levelManager.LoadLevel ("Lose");
	}
}
