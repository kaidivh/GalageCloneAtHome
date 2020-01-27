using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullySuccd : MonoBehaviour
{
	private PlayerController playerController;
	private bool hasGivenNewVector;
	public Transform NewVector;
    // Start is called before the first frame update
    void Start()
    {/*
		hasGivenNewVector = false;
        GameObject playerControllerObject = GameObject.FindWithTag ("Player"); // find playerController to disable scripts etc.
		if (playerControllerObject != null){
			playerController = playerControllerObject.GetComponent <PlayerController>();
		}
		if (playerController == null){
			Debug.Log ("Cannot find 'PlayerController' script.");
		}*/
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other){/*
		if (other.tag != "Player")
		{
			return;
		}
		else{
			playerController.ZeroVelocity();
			other.tag = "CapturedPlayer";
		}*/
	}
	
	void OnTriggerStay2D(Collider2D other){/*
		if (other.tag == "CapturedPlayer" & hasGivenNewVector == false){
			playerController.AcquireSuccLocation(NewVector);
			playerController.CalculateMoveVector(NewVector);
			hasGivenNewVector = true;
		}*/
	}
}
