﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressEnter : MonoBehaviour {

	public SpriteRenderer mySprite;
	public float timeRepeat = 0.5f;

	// Use this for initialization
	void Start () {
		mySprite = GetComponent<SpriteRenderer> ();
		StartCoroutine(blinkText());		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public IEnumerator blinkText(){

		while(enabled){
	
			mySprite.color = new Color (0f,0f,0f,0f);

			yield return new WaitForSeconds (timeRepeat);

		
			mySprite.color = new Color (1f,1f,1f,1f); 

			yield return new WaitForSeconds (timeRepeat);	
		}
	}
}
