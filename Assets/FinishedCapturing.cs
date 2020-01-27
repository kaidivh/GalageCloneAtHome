using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishedCapturing : MonoBehaviour
{
	public GameObject bossWhosSuccin;
	private GameController gameController;
	private PlayerController playerController;
	private GameObject playerControllerObject;
    // Start is called before the first frame update
    void Start()
    {/*
        playerControllerObject = GameObject.FindWithTag ("Player"); // find playerController to disable scripts etc.
		if (playerControllerObject != null){
			playerController = playerControllerObject.GetComponent <PlayerController>();
		}
		if (playerController == null){
			Debug.Log ("Cannot find 'PlayerController' script.");
		}
		
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController"); // find game controller to handle bullet counts, score etc
		if (gameControllerObject != null){
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null){
			Debug.Log ("Cannot find 'GameController' script.");
		}
		*/
    }

    void OnTriggerEnter2D(Collider2D other){/*
		if (other.tag != "CapturedPlayer")
		{
			return;
		}
		if (other.tag == "CapturedPlayer"){			
			playerController.SuccToggle();
			playerController.ZeroVelocity();
			gameController.livesTotal(-1);
			playerController.BossSuccingMe(bossWhosSuccin);
		}
	}
	
	void OnTriggerStay2D(Collider2D other){
		if (other.tag != "CapturedPlayer")
		{
			return;
		}
		if (other.tag == "CapturedPlayer"){
			playerControllerObject.transform.position = transform.position;
		}*/
	}
}
