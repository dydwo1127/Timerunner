using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsMaker : MonoBehaviour {

    public List<GameObject> Obstacles;
    public float obsInstanceRate;

    float obsInstanceTime = 0;

	void Start () {
		
	}
	
	void Update ()
    {
        obsInstanceTime += Time.deltaTime;

        if(obsInstanceTime > obsInstanceRate)
        {
            Instantiate(Obstacles[Random.Range(0, 2)]);
            obsInstanceTime = 0;
        }
	}
}
