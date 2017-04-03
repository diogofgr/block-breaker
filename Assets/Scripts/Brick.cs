using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	private LevelManager levelManager;
	public static int numberOfBreakableBricks = 0;

	private int timesHit;
	//TODO: load hitSprites directly in the code, instead of the inspector.
	public Sprite[] hitSprites;
	public int maxHits = 1;
	private bool isBreakable;

	public AudioClip crack;

	void Awake(){
	}

	// Use this for initialization
	void Start () {
		if (this.tag == "Breakable"){
			isBreakable = true;
			numberOfBreakableBricks ++;
		}
		timesHit = 0;
		levelManager = Object.FindObjectOfType<LevelManager> ();
		LoadNextSprite ();
		
	}
	
	// Update is called once per frame
	void Update () {
		// request next level, for development:
		if(Input.GetMouseButtonDown(2)){
			WinLevel ();
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (isBreakable){
			timesHit++;
			LoadNextSprite ();
			HandleDestruction ();
		}

	}

	void LoadNextSprite(){
		int hitSpritesIndex = Mathf.Clamp (timesHit, 0, 2);
		this.GetComponent<SpriteRenderer>().sprite = hitSprites [hitSpritesIndex];
	}


	void HandleDestruction(){
		// destroy after reaching the maximum hits the block can take:
		bool isBreakable = (this.tag == "Breakable"); 
		if ( (timesHit >= maxHits) && isBreakable ){
			AudioSource.PlayClipAtPoint (crack, transform.position, 0.25f); // play destruction sound
			Destroy (gameObject, 0.1f);
			numberOfBreakableBricks--;
			print ("bricks left :" + numberOfBreakableBricks);
			if (numberOfBreakableBricks == 0){
				WinLevel ();
			}
		}
	}
	// TODO: replace this method with the actual capability of winning a level
	void WinLevel(){
		levelManager.LoadNextLevel();
	}
}
