using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccaDelphia : MonoBehaviour
{
	
	private GameController gameController;
	private PlayerController playerController;
	private InFormation inFormation;
	public Transform finishedSuccLocation;
	
	private bool runOnce;
	
	void Start()
	{/*
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController"); // find game controller to handle bullet counts, score etc
		if (gameControllerObject != null){
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null){
			Debug.Log ("Cannot find 'GameController' script.");
		}
		
		GameObject playerControllerObject = GameObject.FindWithTag ("Player"); // find playerController to disable scripts etc.
		if (playerControllerObject != null){
			playerController = playerControllerObject.GetComponent <PlayerController>();
		}
		if (playerController == null){
			Debug.Log ("Cannot find 'PlayerController' script.");
		}
		inFormation = this.transform.parent.gameObject.GetComponent<InFormation>();
		*/
	}
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
	{/*
		if (other.tag == "Player" & runOnce == false){
			playerController.playerSetTag(); //sets tag to captured
			playerController.AcquireSuccLocation(finishedSuccLocation);
			playerController.SuccToggle();//if player gets sucked, toggles it on.
			runOnce = true;
			inFormation.SuccToggle();
		}*/
	}
}
