using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingNpc : MonoBehaviour {

    bool isMoving = false;

	void Start ()
    {
        StartCoroutine(MoveDelay());
	}
	
	void Update ()
    {
		if(isMoving)
        {
            transform.Translate(-4 * Time.deltaTime, 0, 0);
        }
	}

    IEnumerator MoveDelay()
    {
        isMoving = true;
        yield return new WaitForSeconds(2);
        isMoving = false;
    }
}
