using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByContact : MonoBehaviour
{	
	
	
	private GameController gameController;
	private PlayExplosion explosionHandler;
	
	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController"); // find game controller to handle bullet counts, score etc
		if (gameControllerObject != null){
			gameController = gameControllerObject.GetComponent <GameController>();
		}
		if (gameController == null){
			Debug.Log ("Cannot find 'GameController' script.");
		}
		
		GameObject explosionHandlerObject = GameObject.FindWithTag ("Explosion"); // find game controller to handle bullet counts, score etc
		if (explosionHandlerObject != null){
			explosionHandler = gameControllerObject.GetComponent <PlayExplosion>();
		}
		if (explosionHandlerObject == null){
			Debug.Log ("Cannot find 'Explosion' script.");
		}
		
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == this.tag || other.tag == "Boundary" || this.tag == "PowerUp" || other.tag == "PowerUp")// || other.tag == "SuccThing" || other.tag == "CapturedPlayer" || other.tag == "FullySuccd")
			{
				return;
			}
		/*if (other.tag == "PowerupSpawn"){ yeesh, the succ didn't work
			return;
		}
		if (other.tag == "Boss" & this.tag == "CapturedPlayer"){
			return;
		}
		if (this.tag == "Boss" & other.tag == "CapturedPlayer"){
			return;
		}
		if (this.tag == "Boss" & other.tag == "Enemy"){
			return;
		}
		if (this.tag == "Enemy" & other.tag == "Boss"){
			return;
		}

		if (this.tag == "PowerupSpawn" || other.tag == "PowerupSpawn"){
			return;
		}

		if (other.tag == "InjuredBoss" & this.tag == "CapturedPlayer"){
			return;
		}
		if (this.tag == "InjuredBoss" & other.tag == "CapturedPlayer"){
			return;
		}
		if (this.tag == "SuccThing" || other.tag == "SuccThing"){
			return;
		}*/
		
		if (other.tag == "Bullet"){
			//explosionHandler.PlaySound();
			gameController.bulletTotal(-1); // this is running twice?			
			gameController.bulletTotal(1);//this fixes it???
		}
		if (this.tag == "Player"){
			//Debug.Log("Lives total is ran");
			//explosionHandler.PlaySound();
			gameController.livesTotal(-1);
		}
		if (this.tag == "Enemy"){
			gameController.updateTotalEnemiesDestroyed();
			gameController.updateTotalScore(100);
		}
		Destroy(other.gameObject);
		if (this.tag == "InjuredBoss"){
			gameController.updateTotalEnemiesDestroyed();
			gameController.updateTotalEnemiesDestroyed();//boss takes 2 shots to kill, should count as "2" for accuracy
			gameController.updateTotalScore(1500);
		}
		if (this.tag != "Boss"){
			Destroy(gameObject);
		}
		if (this.tag == "Boss"){
			this.tag = "InjuredBoss";
		}
	}
}
