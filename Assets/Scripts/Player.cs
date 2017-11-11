using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float jumpSpeed;

    Animator anim;

    int jumpCount = 0;
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	void Update ()
    {
		if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(5 * Time.deltaTime, 0, 0);
            transform.localScale = new Vector3(1, 1, 1);
            anim.Play("run");
        }
        else if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(-5 * Time.deltaTime, 0, 0);
            transform.localScale = new Vector3(-1, 1, 1);
            anim.Play("run");
        }
        else
        {
            
        }

        if(Input.GetKeyDown(KeyCode.Space) && IsOnFloor() && jumpCount <2)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, jumpSpeed, 0);
            jumpCount++;
        }
	}

    bool IsOnFloor()
    {
        return true;
        //땅에 닿으면 true반환하는 코드
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Floor")
        {
            jumpCount = 0;
        }

        if(collision.gameObject.tag == "Obs")
        {
            Destroy(collision.gameObject);
        }
    }
}
