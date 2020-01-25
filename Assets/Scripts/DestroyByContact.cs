using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{	
	
	
	private GameController gameController;
	
	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController"); // find game controller to handle bullet counts, score etc
		if (gameControllerObject != null){
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null){
			Debug.Log ("Cannot find 'GameController' script.");
		}
		
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == this.tag || other.tag == "Boundary")
			{
				return;
			}
			if (other.tag == "Bullet"){
				gameController.bulletTotal(-1); // this is running twice?			
				gameController.bulletTotal(1);//WHAT THE !@$%
			}
		if (other.tag == "Player"){
			gameController.livesTotal(-1);
		}
		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}
