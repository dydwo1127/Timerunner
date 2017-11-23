using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obsTest : MonoBehaviour {

    public float speed;
    public float initialYPosition;

	void Start ()
    {
        transform.position = new Vector3(13, initialYPosition, 0);
	}
	
	void Update ()
    {
        transform.Translate(-speed * Time.deltaTime, 0, 0);

        if(transform.position.x < -15)
        {
            Destroy(gameObject);
        }
	}
}
