using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBoundary : MonoBehaviour
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
	
    void OnTriggerExit2D(Collider2D other)
	{
		{
			if (other.tag == "Bullet"){				
				Destroy(other.gameObject);
				gameController.bulletTotal(-1);
			}
		}
	}
}
