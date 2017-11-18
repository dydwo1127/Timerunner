using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public int stageTime;
    public float backgroundSpeed;

    public GameObject background;

    Vector2 backgroundOffset;

	void Start ()
    {
        backgroundOffset = background.GetComponent<SpriteRenderer>().material.mainTextureOffset;
	}
	
	void Update ()
    {
        backgroundOffset.x = backgroundSpeed * Time.deltaTime;
		if(Time.time > stageTime)
        {
            GetComponent<ObsMaker>().isTimeRunning = false;
        }
	}
}
