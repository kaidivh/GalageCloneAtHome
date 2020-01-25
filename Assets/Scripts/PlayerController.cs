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
    public float fireRate;

    private float nextFire;
	private int fireCount;
	
	private GameController gameController;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
		
		
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
		
        if (Input.GetButtonDown("Fire1") & (fireCount < 2))
        {
			gameController.bulletTotal(1);
            //nextFire = Time.time + fireRate; make it so that hold down continues firing slower
			Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
        }
        
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
		
		rb.position = new Vector2
          (
               Mathf.Clamp(rb.position.x, xMin, xMax),
               -4.8f
          );


        Vector2 movement = new Vector2(moveHorizontal, 0.0f);
        rb.velocity = movement * speed;

        
    }
}
