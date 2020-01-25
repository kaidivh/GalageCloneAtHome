using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightPattern : MonoBehaviour
{
	public GameObject [] PathNode;
	
	public float MoveSpeed;
	public GameObject Enemy;
	
	private float Timer;
	private int CurrentNode;
	
	private Vector2 startPosition;
	
	
	static Vector3 CurrentPositionHolder;
	
    // Start is called before the first frame update
    void Start()
    {
        Enemy = GameObject.FindGameObjectWithTag ("Enemy");
		//PathNode = GetComponentsInChildren<Node> ();
		CheckNode();
		startPosition = Enemy.transform.position;
	}
		
	
	void CheckNode()
	{
		if(CurrentNode<PathNode.Length -1){
			Timer = 0;
			CurrentPositionHolder = PathNode [CurrentNode].transform.position;
			if (CurrentNode!=0){
				startPosition = PathNode [CurrentNode-1].transform.position;
			}
		}
	}

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime * MoveSpeed;
		if (Enemy.transform.position != CurrentPositionHolder){
				Enemy.transform.position = Vector3.Lerp(startPosition, CurrentPositionHolder, Timer);
			}
			else{
				if (CurrentNode < PathNode.Length - 1){
					CurrentNode++;
					CheckNode();
			}
		}
	}
}
