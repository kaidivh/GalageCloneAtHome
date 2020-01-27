using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PathCreation;

public class PowerUpPathing : MonoBehaviour
{
	public PathCreator path1;
	public PathCreator path2;
	public EndOfPathInstruction end;
	public float speed;
	private float distanceTravelled;
	
	private int whichPath;
	
    // Start is called before the first frame update
    void Start()
    {
		whichPath = Random.Range(0,2);
    }

    // Update is called once per frame
    void Update()
    {
        distanceTravelled += speed * Time.deltaTime; //this chunk is initial flight
			
		if (whichPath == 0){
			transform.position = path1.path.GetPointAtDistance(distanceTravelled, end);
		}
		if (whichPath == 1){
			transform.position = path2.path.GetPointAtDistance(distanceTravelled, end);
		}
    }
}
