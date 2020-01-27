using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnPowerUpScripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.x == 0)
		{
			this.GetComponent<PowerUpPathing>().enabled = true;
		}
    }
}
