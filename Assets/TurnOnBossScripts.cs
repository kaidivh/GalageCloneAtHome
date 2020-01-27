using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOnBossScripts : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.x == 0)
		{
			this.GetComponent<BossFlightPath>().enabled = true;
			this.GetComponent<InFormation>().enabled = true;
		}
    }
}
