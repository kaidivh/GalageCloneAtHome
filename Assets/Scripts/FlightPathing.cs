using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class FlightPathing : MonoBehaviour
{
	public PathCreator pathCreator;
	public EndOfPathInstruction end;
	public float speed;
	
	public bool hasCompletedPath;
	
	private bool isBossEnemy;
	
	private float distanceTravelled;
	
	private GameController gameController;
	
	private int blockPlacement;
	
    // Start is called before the first frame update
    void Start()
    {
		hasCompletedPath = false;
		isBossEnemy = false;
		
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController"); // find game controller to handle bullet counts, score etc
		if (gameControllerObject != null){
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null){
			Debug.Log ("Cannot find 'GameController' script.");
		}
		
		
    }

    // Update is called once per frame
    void Update()
    {
		//Debug.Log(distanceTravelled);
			
				distanceTravelled += speed * Time.deltaTime; //this chunk is initial flight
			
				transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, end);
				
				if (distanceTravelled > 15f){
					hasCompletedPath = true;
					gameObject.GetComponent<InFormation>().CompletedPath(); 
					//then execute some function for other script to activate
					this.enabled = false;
				}
		
		//transform.rotation = Quaternion.Euler(pathCreator.path.GetPointAtDistance(distanceTravelled));
		//transform.LookAt(pathCreator.path.GetPointAtDistance(distanceTravelled, end));
		//transform.right = lookToward.position - transform.position;
    }
}
