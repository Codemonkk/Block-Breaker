﻿using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {
	private Paddle paddle; 
	
	private bool hasStarted = false;
	private Vector3 paddletoBallVector;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle>();
		paddletoBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(!hasStarted){
			//Lock the ball relative to paddle
			this.transform.position = paddle.transform.position + paddletoBallVector;
			
			//Wait for a mouse press to launch
			if(Input.GetMouseButtonDown(0)){
				print("Mouse clicked, ball launch");
				hasStarted = true;
				this.rigidbody2D.velocity = new Vector2 (2f,10f);
				}
			}
    }

	void OnCollisionEnter2D(Collision2D collision){
		//Ball does not trigger sound when brick is destroyed.
		//Not 100% sure why,possibly because brick isn't there.
		Vector2 tweak = new Vector2 (Random.Range (0f, 0.2f), Random.Range (0f, 0.2f));
		if (hasStarted) {
			audio.Play ();
			rigidbody2D.velocity += tweak;
		}
	}
}
