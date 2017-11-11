using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsMaker : MonoBehaviour {

    public List<GameObject> Obstacles;
    public float obsInstanceRate;

    public bool isTimeRunning = true;

    float obsInstanceTime = 0;

	void Start () {
		
	}
	
	void Update ()
    {
        obsInstanceTime += Time.deltaTime;

        if(obsInstanceTime > obsInstanceRate && isTimeRunning)
        {
            Instantiate(Obstacles[Random.Range(0, 3)]);
            obsInstanceTime = 0;
        }
	}
}
