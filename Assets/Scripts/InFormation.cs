using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class InFormation : MonoBehaviour
{
	public PathCreator pathCreator1;
	public PathCreator pathCreator2;
	public PathCreator pathCreator3;
	public PathCreator pathCreator4;
	public PathCreator returnPath;
	
	public EndOfPathInstruction end;
	private float distanceTravelled;
	
	public bool hasCompletedPath;
	public bool isBossEnemy;
	public bool inFormation;
	public bool hasReceivedMarchingOrdersCheiftain;//I'mLosingMyMind
	public bool swooping;
	
	private float swoopPath;//random between 1-4, determines how they swoop
	private float willShoot;//random between 0/1, <.5 no, >=.5 will shoot
	private bool setShoot;//prevent overwriting willShoot
	private bool hasFinishedSwoop;
	
	private float anchorPointPingPong; // anchor for InFormation ping pong bing bong
	
	private int swoopGuarantee;
	
	
	
	public float speed;
	
	public Transform [] Node;
	
	private GameController gameController;
	
	private int blockPlacement;
	
    // Start is called before the first frame update
    void Start()
    {
		swoopGuarantee = 0;
        hasCompletedPath = false;
		hasFinishedSwoop = false;
		isBossEnemy = false;
		inFormation = false;
		hasReceivedMarchingOrdersCheiftain = false;
		swooping = false;
		anchorPointPingPong = 0;
		setShoot = false;
		distanceTravelled = 0;
		
		
		this.GetComponent<FlightPathing>().enabled = true;
		
		
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController"); // find game controller to handle bullet counts, score etc
		if (gameControllerObject != null){
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null){
			Debug.Log ("Cannot find 'GameController' script.");
		}
		blockPlacement = gameController.blockPlacement(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (hasCompletedPath == true & isBossEnemy == false & inFormation == false){//Block Formation Time
			/*if (hasReceivedMarchingOrdersCheiftain == false){
				blockPlacement = gameController.blockPlacement(); // where do I go sir?
				hasReceivedMarchingOrdersCheiftain = true;
			}*/ //I don't think this is necessary anymore
			
			//Debug.Log(blockPlacement);
			//Debug.Log(Node[blockPlacement].position);
			transform.position = Vector3.MoveTowards(transform.position, Node[blockPlacement].position, (speed * Time.deltaTime));
			
			
			//move to one of the 20 minion placements or one of 4 boss placements
			//ask GameController Nicely where I should go
		}
		if (hasCompletedPath == true & (transform.position == Node[blockPlacement].position)){
			anchorPointPingPong = transform.position.x;
			inFormation = true;//then do the PingPong
		}
		if (inFormation == true & swooping == false){
			transform.position = new Vector3((anchorPointPingPong + Mathf.PingPong(Time.time, 0.5f)), transform.position.y, transform.position.z);
			if (((Random.Range(0, 10f)>9.999f) || swoopGuarantee>10000) & (gameController.enemyWaveCount == 5)){
				swoopGuarantee++;
				swooping = true;
			}
				
		}
		if (swooping == true){//swoops
			
			if (setShoot == false){//set shoot and swoop tha woop
				willShoot = Random.Range(0, 1);
				swoopPath = Random.Range(0, 4); // returns an int 0-3
				//Debug.Log("I swooped");
				setShoot = true;
			} // take swoopingPath
			if (swoopPath == 0){
				distanceTravelled += speed * Time.deltaTime; //this chunk is swoop flight
			
				transform.position = pathCreator1.path.GetPointAtDistance(distanceTravelled, end);
			if ((willShoot >0.5f) & (transform.position == pathCreator1.path.GetPointAtDistance(10))){//find halfwaypoint{
				Debug.Log("Shoot here");
				setShoot = true;//shoot bullet at player halfway through path.
			}
			if (distanceTravelled > 30f){
				swooping = false;
				swoopGuarantee = 0;
				hasFinishedSwoop = true;
				distanceTravelled = 0;
				//Debug.Log("SwoopingIsFalse");
				inFormation = false;
			}
			}
			if (swoopPath == 1){
				distanceTravelled += speed * Time.deltaTime; //this chunk is swoop flight
			
				transform.position = pathCreator2.path.GetPointAtDistance(distanceTravelled, end);
			if ((willShoot >0.5f) & (transform.position == pathCreator2.path.GetPointAtDistance(10))){//find halfwaypoint{
				Debug.Log("Shoot here");
				setShoot = true;//shoot bullet at player halfway through path.
			}
			if (distanceTravelled > 30f){
				swooping = false;
				swoopGuarantee = 0;
				hasFinishedSwoop = true;			
				distanceTravelled = 0;
				//Debug.Log("SwoopingIsFalse");
				inFormation = false;
			}
			}
			if (swoopPath == 2){
				distanceTravelled += speed * Time.deltaTime; //this chunk is swoop flight
			
				transform.position = pathCreator3.path.GetPointAtDistance(distanceTravelled, end);
			if ((willShoot >0.5f) & (transform.position == pathCreator3.path.GetPointAtDistance(10))){//find halfwaypoint{
				Debug.Log("Shoot here");
				setShoot = true;//shoot bullet at player halfway through path.
			}
			if (distanceTravelled > 30f){
				swooping = false;
				swoopGuarantee = 0;
				hasFinishedSwoop = true;
				distanceTravelled = 0;
				//Debug.Log("SwoopingIsFalse");
				inFormation = false;
			}
			}
			if (swoopPath == 3){
				distanceTravelled += speed * Time.deltaTime; //this chunk is swoop flight
			
				transform.position = pathCreator4.path.GetPointAtDistance(distanceTravelled, end);
			if ((willShoot >0.5f) & (transform.position == pathCreator4.path.GetPointAtDistance(10))){//find halfwaypoint{
				Debug.Log("Shoot here");
				setShoot = true;//shoot bullet at player halfway through path.
			}
			if (distanceTravelled > 30f){
				swooping = false;
				swoopGuarantee = 0;
				hasFinishedSwoop = true;
				distanceTravelled = 0;
				//Debug.Log("SwoopingIsFalse");
				inFormation = false;
			}
			}
			
		}
		if (hasFinishedSwoop == true){
			
			distanceTravelled += speed * Time.deltaTime; //this chunk is return flight
			
			transform.position = returnPath.path.GetPointAtDistance(distanceTravelled, end);
			if (distanceTravelled > 2f){
				hasFinishedSwoop = false;
			}
		}
    }
	
	public void CompletedPath()
	{
		hasCompletedPath = true;
	}
	
	public void BossType()
	{
		isBossEnemy = true;
	}
}
