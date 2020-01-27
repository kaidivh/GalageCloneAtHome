using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShot : MonoBehaviour
{
	private GameObject [] shootLoc;
	public float speed;
	private Transform targetLoc;
	private Vector3 moveVector;
	private int shootChoice;
	
    // Start is called before the first frame update
    void Start()
    {
		shootChoice = Random.Range(0,5);
        shootLoc = GameObject.FindGameObjectsWithTag("ShootHere");
		targetLoc = shootLoc[shootChoice].transform;
		CalculateMoveVector(targetLoc);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += moveVector * speed * Time.deltaTime;
    }
	
	public void CalculateMoveVector(Transform target)  {
		moveVector = (target.position - transform.position).normalized;
	}
}
