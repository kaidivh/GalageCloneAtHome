using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public int fireCount; //player bullets on screen cannot exceed 2 (4 if powerup)
	public int levelCount;
	public int livesCount;
	public GameObject shipWithPath1;
	public GameObject shipWithPath2;
	public GameObject shipWithPath3;
	public GameObject shipWithPath4;
		 
	private bool hasDied;
	private bool gameOver;
	
	public GameObject player;
	
	public int enemyWaveCount;
	
	
	private int blockPlacementPos; //array is indexed at 0
	private int bossBlockPlacementPos;
	
    // Start is called before the first frame update
    void Start()
    {
		bossBlockPlacementPos = -1;
		blockPlacementPos = -1; //if we start at 0 the index is wonky
        fireCount = 0; // DestroyByContact runs -1 twice
		levelCount = 1;
		livesCount = 3;
		hasDied = false;
		gameOver = false;
		
		StartCoroutine(SpawnEnemies());
		
    }

    // Update is called once per frame
    void Update()
    {
        if (livesCount == 0)
		{
			GameOver();
		}
		if (hasDied == true && gameOver == false)
		{
			RespawnPlayer();
		}
    }
	
	IEnumerator SpawnEnemies()//this handles the spawning routines
	{
		while (enemyWaveCount < 5) // you can handle level here too
		{//spawn the level, then integrate levelCount;	//instantiate Ship at Spawn.
			yield return new WaitForSeconds(1);	
			Instantiate(shipWithPath1, new Vector3(0, 10, 0), Quaternion.identity); //needs to enable scripts of instantiated objects
			Instantiate(shipWithPath2, new Vector3(0, 11, 0), Quaternion.identity);
			yield return new WaitForSeconds(1);
			Instantiate(shipWithPath3, new Vector3(0, 10, 0), Quaternion.identity); //needs to enable scripts of instantiated objects
			Instantiate(shipWithPath4, new Vector3(0, 11, 0), Quaternion.identity);
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
				hasDied = false;
			}
		}
	}
	
	bool GameOver()
	{
		gameOver = true;
		return gameOver; //do a gameover screen
	}
	public int bulletTotal(int fireCountMod)
	{
		fireCount = (fireCount + fireCountMod); // things call Game Controller to let it know what total firecount is
		Debug.Log(fireCount);
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
		if (blockPlacementPos == 20)
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
}
