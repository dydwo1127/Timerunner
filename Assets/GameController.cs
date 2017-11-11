using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public int stageTime;
    
	void Start ()
    {
        
	}
	
	void Update ()
    {
		if(Time.time > stageTime)
        {
            GetComponent<ObsMaker>().isTimeRunning = false;
        }
	}
}
