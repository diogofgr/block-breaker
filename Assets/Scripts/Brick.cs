using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	private LevelManager levelManager;

	public int maxHits;
	private int timesHit;
	public Sprite[] hitSprites;

	// Use this for initialization
	void Start () {
		timesHit = 0;
		levelManager = Object.FindObjectOfType<LevelManager> ();
		LoadNextSprite ();
		
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetMouseButtonDown(2)){
			SimulateWin ();
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		timesHit++;
		LoadNextSprite ();

		// destroy after reaching the maximum hits the block can take:
		if (timesHit >= maxHits){
			Destroy (gameObject, 0.1f);
		}

	}

	void LoadNextSprite(){
		int hitSpritesIndex = Mathf.Clamp (timesHit, 0, 2);
		print ("sprite index: " + hitSpritesIndex);
		this.GetComponent<SpriteRenderer>().sprite = hitSprites [hitSpritesIndex];
	}

	// TODO: replace this method with the actual capability of winning a level
	void SimulateWin(){
		levelManager.LoadNextLevel();
	}
}
