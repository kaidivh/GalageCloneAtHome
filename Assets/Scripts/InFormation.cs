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
	//public PathCreator bossSuccPath1;
	//public PathCreator bossSuccFinishPath1;
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
	private bool hasShot;
	//private bool hasCompletedSucc;
	//private bool currentlySuccing;
	
	private float anchorPointPingPong; // anchor for InFormation ping pong bing bong
	
	private int swoopGuarantee;
	
	public GameObject enemyBullet;
	
	
	public float speed;
	
	public Transform [] Node;
	
	private GameController gameController;
	
	private int blockPlacement;
	private int bossBlockPlacement;
	
	
    // Start is called before the first frame update
    void Start()
    {
		swoopGuarantee = 0;
        hasCompletedPath = false;
		hasFinishedSwoop = false;
		//hasCompletedSucc = false;
		//currentlySuccing = false;
		isBossEnemy = false;
		if (this.tag == "Boss"){
			isBossEnemy = true;
		}
		inFormation = false;
		hasReceivedMarchingOrdersCheiftain = false;
		swooping = false;
		anchorPointPingPong = 0;
		setShoot = false;
		distanceTravelled = 0;
		
		
		
		if (isBossEnemy != true){
			this.GetComponent<FlightPathing>().enabled = true;
		}
		
		
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController"); // find game controller to handle bullet counts, score etc
		if (gameControllerObject != null){
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null){
			Debug.Log ("Cannot find 'GameController' script.");
		}
		if (isBossEnemy != true){
			blockPlacement = gameController.blockPlacement(); 
		}
		if (isBossEnemy == true){
			bossBlockPlacement = gameController.bossBlockPlacement();
			//Debug.Log(bossBlockPlacement);
		}
    }

    // Update is called once per frame
    void Update()
    {
        if (hasCompletedPath == true & isBossEnemy == false & inFormation == false){//Block Formation Time
			
			transform.position = Vector3.MoveTowards(transform.position, Node[blockPlacement].position, (speed * Time.deltaTime));
			
		}
		if (hasCompletedPath == true & isBossEnemy == true & inFormation == false){//Block Formation Time
			
			transform.position = Vector3.MoveTowards(transform.position, Node[bossBlockPlacement].position, (speed * Time.deltaTime));
			
		}
		if (((hasCompletedPath == true & (transform.position == Node[blockPlacement].position)) || ((hasCompletedPath == true & (transform.position == Node[bossBlockPlacement].position))))){
			
			anchorPointPingPong = transform.position.x;
			inFormation = true;//then do the PingPong
		}
		if (inFormation == true & swooping == false){
			transform.position = new Vector3((anchorPointPingPong + Mathf.PingPong(Time.time, 0.5f)), transform.position.y, transform.position.z);
			swoopGuarantee++;
			if (((Random.Range(0, 10f)>9.999f) || swoopGuarantee>10000) & (gameController.enemyWaveCount >= 6)){
				
				swooping = true;
			}
				
		}
		if (swooping == true){//swoops
			
			if (setShoot == false){//set shoot and swoop tha woop
				willShoot = Random.Range(0, 2);
				swoopPath = Random.Range(0, 4); // returns an int 0-3
				//Debug.Log("I swooped");
				setShoot = true;
			} // take swoopingPath
			if (swoopPath == 0){
				distanceTravelled += speed * Time.deltaTime; //this chunk is swoop flight
			
				transform.position = pathCreator1.path.GetPointAtDistance(distanceTravelled, end);
			if ((willShoot == 1) & (distanceTravelled >=3) & hasShot == false){//find halfwaypoint{
				Debug.Log("Shoot here");
				Instantiate(enemyBullet, transform.position, Quaternion.identity);
				hasShot = true;//shoot bullet at player halfway through path.
			}
			if (distanceTravelled > 30f){
				swooping = false;
				swoopGuarantee = 0;
				hasFinishedSwoop = true;
				distanceTravelled = 0;
				hasShot = false;
				//Debug.Log("SwoopingIsFalse");
				inFormation = false;
			}
			}
			if (swoopPath == 1){
				distanceTravelled += speed * Time.deltaTime; //this chunk is swoop flight
			
				transform.position = pathCreator2.path.GetPointAtDistance(distanceTravelled, end);
			if ((willShoot == 1) & (distanceTravelled >=3) & hasShot == false){//find halfwaypoint{
				Debug.Log("Shoot here");
				Instantiate(enemyBullet, transform.position, Quaternion.identity);
				hasShot = true;//shoot bullet at player halfway through path.
			}
			if (distanceTravelled > 30f){
				swooping = false;
				swoopGuarantee = 0;
				hasFinishedSwoop = true;			
				distanceTravelled = 0;
				hasShot = false;
				//Debug.Log("SwoopingIsFalse");
				inFormation = false;
			}
			}
			if (swoopPath == 2){
				distanceTravelled += speed * Time.deltaTime; //this chunk is swoop flight
			
				transform.position = pathCreator3.path.GetPointAtDistance(distanceTravelled, end);
			if ((willShoot == 1) & (distanceTravelled >=3) & hasShot == false){//find halfwaypoint{
				Debug.Log("Shoot here");
				Instantiate(enemyBullet, transform.position, Quaternion.identity);
				hasShot = true;//shoot bullet at player halfway through path.
			}
			if (distanceTravelled > 30f){
				swooping = false;
				swoopGuarantee = 0;
				hasFinishedSwoop = true;
				distanceTravelled = 0;
				hasShot = false;
				//Debug.Log("SwoopingIsFalse");
				inFormation = false;
			}
			}
			if (swoopPath == 3){
				distanceTravelled += speed * Time.deltaTime; //this chunk is swoop flight
			
				transform.position = pathCreator4.path.GetPointAtDistance(distanceTravelled, end);
			if ((willShoot == 1) & (distanceTravelled >=3) & hasShot == false){//find halfwaypoint{
				Debug.Log("Shoot here");
				Instantiate(enemyBullet, transform.position, Quaternion.identity);
				hasShot = true;//shoot bullet at player halfway through path.
			}
			if (distanceTravelled > 30f){
				swooping = false;
				swoopGuarantee = 0;
				hasFinishedSwoop = true;
				distanceTravelled = 0;
				hasShot = false;
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
	
	/*public void SuccToggle(){
		currentlySuccing ^= true;
	}*/
	
	/*IEnumerator PauseForSeconds(float t){
		yield return new WaitForSeconds(t);
		currentlySuccing = false;
	}*/
}
