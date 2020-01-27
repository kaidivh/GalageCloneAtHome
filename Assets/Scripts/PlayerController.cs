using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    public float speed;
    public float xMin;
    public float xMax;
    public GameObject shot;
    public Transform shotSpawn;
	//public Transform targetSuccLocation;
	//private Transform currentLocationWhenSucc;
	//public Transform moveToWhenRescued;
	//private Transform finishedPowerupPosition;
	//public float succSpeed;
	
    public float fireRate;
	
	private float spinRate;

    private float nextFire;
	private int fireCount;
	
	private bool hasPowerUp;
	
	//private bool isBeingSuccd;
	//private bool hasGottenSuccTargetLocation;
	//private bool succPositionLock;
	//private bool succFinished;
	//private bool setSpin;
	//private bool myBossHasDied;
	
	private Vector3 moveVector;
	
	private GameController gameController;
	
	//private GameObject bossSuccingMe;
	//private GameObject playerForPowerup;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		
		hasPowerUp = false;
		//succFinished = false;
		//setSpin = false;
		//myBossHasDied = false;
		
		//isBeingSuccd = false;
		//hasGottenSuccTargetLocation = false;
		
		this.tag = "Player";
		
		
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
        //get input
        //left right and shoot
		//get fire count
		
		fireCount = gameController.fireCount;
		if (this.tag == "Player"){
			if (Input.GetButtonDown("Fire1") & (fireCount < 2) & hasPowerUp == false)
			{
				gameController.bulletTotal(1);
				gameController.updateTotalFired();
				//nextFire = Time.time + fireRate; make it so that hold down continues firing slower
				Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			}
		}
		if (this.tag == "Player"){
			if (Input.GetButtonDown("Fire1") & (fireCount < 10) & hasPowerUp == true)
			{
				gameController.bulletTotal(1);
				gameController.updateTotalFired();
				//nextFire = Time.time + fireRate; make it so that hold down continues firing slower
				Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
			}
		}
        
    }

    private void FixedUpdate()
    {

		
        float moveHorizontal = Input.GetAxis("Horizontal");
		if (this.tag == "Player"){
		rb.position = new Vector2
          (
               Mathf.Clamp(rb.position.x, xMin, xMax),
               -4.8f
          );


        Vector2 movement = new Vector2(moveHorizontal, 0.0f);
        rb.velocity = movement * speed;
		}
		//Debug.Log(isBeingSuccd);
		
		/*if (isBeingSuccd == true){
			if (hasGottenSuccTargetLocation == false){
				rb.velocity = new Vector2(0,0);
				rb.angularVelocity = 0;//make thing stop to get succ
				hasGottenSuccTargetLocation = true;
				//Debug.Log("I have 'stopped' velocity");
				
			}
			//SuccRotate();
			MoveTowardSucc();
		}*/
		
		/*if (this.tag == "CapturedPlayer" & myBossHasDied == true){
				transform.position += moveVector * succSpeed * Time.deltaTime;
				if (transform.position == moveToWhenRescued.position)
				{
					this.tag = "Player";
					gameController.livesTotal(1);//make this happen in "ON TRIGGER ENTER 2D POWERUPSPAWN
				}
			}*/
        
    }
	
	/*public bool SuccToggle(){
		Debug.Log ("I am now toggling the succ");
		return isBeingSuccd ^= true;
	}*/
	
	/*private void MoveTowardSucc(){
		
			//Debug.Log("I should be getting succed here");
			if (succPositionLock == false){
				CalculateMoveVector(targetSuccLocation);
				succPositionLock = true;
			}
			if (succFinished == false){
				transform.position += moveVector * succSpeed * Time.deltaTime;//need a different alg or zeno paradox
				SuccRotate();
			}
			if (succFinished == true){
				transform.position += moveVector * succSpeed * Time.deltaTime;
			}
			
			if (transform.position == targetSuccLocation.position){
				//change this tag, undo isBeingSuccd, yeet
				//Debug.Log("Succ Complete");//complete succ routine
			}
	}
	
	public void CalculateMoveVector(Transform target)  {
		moveVector = (target.position - transform.position).normalized;
	}
	
	public void AcquireSuccLocation(Transform passedTargetLocation){
		targetSuccLocation = passedTargetLocation;
		//Debug.Log("Has gotten succ location");
	}
	
	private void SuccRotate(){
		//Debug.Log("I should be rotating");
		if (setSpin == false){
			spinRate = 0;//spin
			setSpin = true;
		}
		spinRate = spinRate + 20;
		//Debug.Log(spinRate);
		transform.rotation = Quaternion.Euler(new Vector3 (0,0,spinRate));
	}*/
	
	public void ZeroVelocity(){
		rb.velocity = new Vector2(0,0);
		rb.angularVelocity = 0;
		transform.rotation = Quaternion.Euler(new Vector3 (0,0,0));
		//succFinished = true;
		//setSpin = false;
		this.tag = "CapturedPlayer";
	}
	
	/*public void BossSuccingMe(GameObject passedBoss){
		bossSuccingMe = passedBoss;
	}*/
	
	void OnTriggerExit2D(Collider2D other){/*
		if (other.tag != "FullySuccd"){
			return;
		}
		
		if (other.tag == "FullySuccd"){
			//find current player, find their powerup child, move there, switch tag to player
			Debug.Log("My boss has died");
			playerForPowerup = GameObject.FindWithTag("Player");
			moveToWhenRescued = playerForPowerup.transform.Find("2ndShipPowerupLocation");
			finishedPowerupPosition = playerForPowerup.transform.Find("2ndShipLocation");
			CalculateMoveVector(moveToWhenRescued);
			myBossHasDied = true;
			//Boss Dies, Move to PowerupLocation of New Player.
		}*/
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if (other.tag != "PowerUp"){
			return;
		}
		if (other.tag == "PowerUp"){
			hasPowerUp = true;
			Destroy(other.gameObject);
		}
		
	}
	/*public void playerSetTag()
	{
		this.tag = "CapturedPlayer";
	}*/
	
}
