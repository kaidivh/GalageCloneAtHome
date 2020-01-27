using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class BossFlightPath : MonoBehaviour
{
	public PathCreator path1;
	public PathCreator path2;
	public PathCreator path3;
	public PathCreator path4;
	public EndOfPathInstruction end;
	public float speed;
	
	public bool hasCompletedPath;
	
	private int chosenPath;
	private bool hasChosenPath;
	
	private float distanceTravelled;
	
	private GameController gameController;
	
	private int blockPlacement;
	
	
	
    // Start is called before the first frame update
    void Start()
    {
		hasCompletedPath = false;
		hasChosenPath = false;
		
		//this.gameObject.transform.Find("WhereTheSuccThingsAre").gameObject.SetActive(false);
		
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
			if (hasChosenPath == false){
				chosenPath = Random.Range(0,4);// index is zero, range 0-3
				hasChosenPath = true;
			}
				distanceTravelled += speed * Time.deltaTime; //this chunk is initial flight
			if (chosenPath == 0){
				transform.position = path1.path.GetPointAtDistance(distanceTravelled, end);
			}
			if (chosenPath == 1){
				transform.position = path2.path.GetPointAtDistance(distanceTravelled, end);
			}
			if (chosenPath == 2){
				transform.position = path3.path.GetPointAtDistance(distanceTravelled, end);
			}
			if (chosenPath == 3){
				transform.position = path4.path.GetPointAtDistance(distanceTravelled, end);
			}
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
