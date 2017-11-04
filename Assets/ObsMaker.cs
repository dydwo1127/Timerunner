using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObsMaker : MonoBehaviour {

    public List<GameObject> Obstacles;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Instantiate(Obstacles[Random.Range(0, 5)]).transform.position = new Vector3(0,0,0);
        }
	}
}
