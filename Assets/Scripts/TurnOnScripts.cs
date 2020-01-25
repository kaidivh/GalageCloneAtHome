using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnScripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.x == 0)
		{
			this.GetComponent<FlightPathing>().enabled = true;
			this.GetComponent<InFormation>().enabled = true;
		}
    }

    // Update is called once per frame
}
