using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	public int fireCount; //player bullets on screen cannot exceed 2 (4 if powerup)
	public int levelCount;
	public int livesCount;
	public GameObject shipWithPath1;
	public GameObject shipWithPath2;
	public GameObject shipWithPath3;
	public GameObject shipWithPath4;
	public GameObject bossEnemy;
	public GameObject PowerUp;
	
	public Transform [] Node;
	
	//public Text accuracyCountText;
	public Text enemiesKilledCountText;
	public Text scoreText;
	public Text respawnText;
	public Text levelText;
		 
	public bool hasDied;
	private bool gameOver;
	//private float accuracy;
	private int score;
	
	public GameObject player;
	
	public int enemyWaveCount;
	private float totalBulletsFired;
	private float totalEnemiesDestroyed;
	
	
	private int blockPlacementPos; //array is indexed at 0
	private int bossBlockPlacementPos;
	
    // Start is called before the first frame update
    void Start()
    {
		//accuracy = 100f;
		//accuracyCountText.text = "Accuracy: ";
		enemiesKilledCountText.text = "Enemies Killed: ";
		respawnText.text = "";
		
		score = 0;
		scoreText.text = "Score: ";
		totalEnemiesDestroyed = 0f;
		totalBulletsFired = 0f;
		bossBlockPlacementPos = -1;
		blockPlacementPos = -1; //if we start at 0 the index is wonky
        fireCount = 0; // DestroyByContact runs -1 twice
		levelCount = 1;
		livesCount = 3;
		levelText.text = "Level: " + levelCount;
		hasDied = false;
		gameOver = false;
		
		StartCoroutine(SpawnEnemies());
		
    }

    // Update is called once per frame
    void Update()
    {
        if (livesCount <= 0)
		{
			GameOver();
		}
		if (hasDied == true && gameOver == false)
		{
			respawnText.text = "Press Space to Respawn!";
			RespawnPlayer();
		}
		
		if ((gameOver == true) & Input.GetKeyDown("space")){
			SceneManager.LoadScene("MainMenu");
		}
		
		if (Input.GetKeyDown("escape")){
			Application.Quit();
		}
		
		//accuracyCountText.text = "Accuracy: " + accuracy + "%";
		enemiesKilledCountText.text = "Enemies killed: " + totalEnemiesDestroyed;
		scoreText.text = "Score: " + score;
		levelText.text = "Level: " + levelCount;
		if (totalEnemiesDestroyed >= 48 & levelCount == 1){
			levelCount++;
			SetNewLevelPattern();//pass this level count if you make a future version
			StartCoroutine(SpawnEnemies());
		}
		if (totalEnemiesDestroyed >= 96 & levelCount == 2){
			GameOver();
			respawnText.text = "You win! Press Space to Enter Main Menu!";
			levelCount++;
			
		}
    }
	
	IEnumerator SpawnEnemies()//this handles the spawning routines
	{
		while (enemyWaveCount < 10 & levelCount == 1) // you can handle level here too
		{//spawn the level, then integrate levelCount;	//instantiate Ship at Spawn.
			yield return new WaitForSeconds(1);	
			Instantiate(shipWithPath1, new Vector3(0, 10, 0), Quaternion.identity); //needs to enable scripts of instantiated objects
			Instantiate(shipWithPath2, new Vector3(0, 11, 0), Quaternion.identity);
			yield return new WaitForSeconds(1);
			Instantiate(shipWithPath3, new Vector3(0, 10, 0), Quaternion.identity); //needs to enable scripts of instantiated objects
			Instantiate(shipWithPath4, new Vector3(0, 11, 0), Quaternion.identity);
			if ((enemyWaveCount == 2 ) || (enemyWaveCount == 4) || (enemyWaveCount == 6) || (enemyWaveCount == 8)){
				Instantiate(bossEnemy, new Vector3(0, 11, 0), Quaternion.identity);
			}
			if (enemyWaveCount == 7){
				Instantiate(PowerUp, new Vector3(0, 3, 0), Quaternion.identity);
			}
			yield return new WaitForSeconds(1);
			enemyWaveCount++;
		}
		while (enemyWaveCount < 10 & levelCount == 2) // you can handle level here too
		{//spawn the level, then integrate levelCount;	//instantiate Ship at Spawn.
			yield return new WaitForSeconds(1);	
			Instantiate(shipWithPath1, new Vector3(0, 10, 0), Quaternion.identity); //needs to enable scripts of instantiated objects
			Instantiate(shipWithPath2, new Vector3(0, 11, 0), Quaternion.identity);
			yield return new WaitForSeconds(1);
			Instantiate(shipWithPath3, new Vector3(0, 10, 0), Quaternion.identity); //needs to enable scripts of instantiated objects
			Instantiate(shipWithPath4, new Vector3(0, 11, 0), Quaternion.identity);
			if ((enemyWaveCount == 2 ) || (enemyWaveCount == 4) || (enemyWaveCount == 6) || (enemyWaveCount == 8)){
				Instantiate(bossEnemy, new Vector3(0, 11, 0), Quaternion.identity);
			}
			if (enemyWaveCount == 7){
				Instantiate(PowerUp, new Vector3(0, 12, 0), Quaternion.identity);
			}
			yield return new WaitForSeconds(1);
			enemyWaveCount++;
		}
	}
	
	void RespawnPlayer()
	{
		if (hasDied == true)
		{
			if (Input.GetKeyDown("space")){
				Debug.Log("Spawning Player");
				Instantiate(player, new Vector3(0, -4.8f, 0), Quaternion.identity);
				respawnText.text = " ";
				hasDied = false;
				
			}
		}
	}
	
	private void GameOver()
	{
		gameOver = true;
		respawnText.text = "Game Over! Press Space to enter Main Menu!"; //do a gameover screen
	}
	public int bulletTotal(int fireCountMod)
	{
		fireCount = (fireCount + fireCountMod); // things call Game Controller to let it know what total firecount is
		//Debug.Log(fireCount);
		return fireCount;
	}
	
	public int livesTotal(int lifeCountMod)
	{
		livesCount = (livesCount + lifeCountMod);
		if (lifeCountMod < 0)
		{
			hasDied = true;
		}
		return livesCount;
	}
	
	public int blockPlacement()
	{
		blockPlacementPos++;
		if (blockPlacementPos == 40)
		{
			blockPlacementPos = 0;
		}
		return blockPlacementPos;
	}
	
	public int bossBlockPlacement()
	{
		bossBlockPlacementPos++;
		if (bossBlockPlacementPos == 4)
		{
			bossBlockPlacementPos = 0;
		}
		return bossBlockPlacementPos;
	}
	public void updateTotalFired(){
		totalBulletsFired++;
		Debug.Log(totalBulletsFired);
		//Debug.Log(accuracy);
	}
	public void updateTotalEnemiesDestroyed(){
		totalEnemiesDestroyed++;
		/*if (totalEnemiesDestroyed >= 1){
			accuracy = (totalEnemiesDestroyed/totalBulletsFired);
			accuracy = Mathf.Round(accuracy * 100f) / 100f;
			accuracy = accuracy*100;
		}*/
	}
	public void updateTotalScore(int scoreMod)
	{
		score += scoreMod;
	}
	
	private void SetNewLevelPattern(){
		for (int i = 0; i <= 40; i++){
			if (i%2 == 0){
				Node[i].transform.position += new Vector3 (0.5f, 0.25f, 0);
			};
		}
		enemyWaveCount = 0;
	}
}
