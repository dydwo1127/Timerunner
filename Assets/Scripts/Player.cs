using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float jumpSpeed;
    public BoxCollider2D standCollider;
    public BoxCollider2D slideCollider;
    public GameController GC;

    Animator anim;

    int jumpCount = 0;
    bool gameOver = false;
	void Start () {
        anim = GetComponent<Animator>();
        standCollider.enabled = true;
        slideCollider.enabled = false;

	}
	
	void Update ()
    {
		if(Input.GetKey(KeyCode.D))
        {
            transform.Translate(5 * Time.deltaTime, 0, 0);
            transform.localScale = new Vector3(1, 1, 1);
            anim.Play("player_run");
        }
        else if(Input.GetKey(KeyCode.A))
        {
            transform.Translate(-5 * Time.deltaTime, 0, 0);
            transform.localScale = new Vector3(-1, 1, 1);
            anim.Play("player_run");
        }
        else
        {
            
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
        if(Input.GetKeyDown(KeyCode.LeftControl))
        {
            Slide();
        }
        if(Input.GetKeyUp(KeyCode.LeftControl))
        {
            SlideUp();
        }
        if(!gameOver)
        {
            transform.position = new Vector3(transform.position.x, Mathf.Max(transform.position.y, -1.35f), 0);
        }
	}

    public void Jump()
    {
        if (IsOnFloor() && jumpCount < 2)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, jumpSpeed, 0);
            jumpCount++;
        }
    }

    public void Slide()
    {
        anim.SetTrigger("slide");
        slideCollider.enabled = true;
        standCollider.enabled = false;
    }

    public void SlideUp()
    {
        anim.SetTrigger("slideUp");
        standCollider.enabled = true;
        slideCollider.enabled = false;
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
            gameOver = true;
            Destroy(collision.gameObject);
            GC.GameOver();
        }
        if(collision.gameObject.tag == "Pit")
        {
            gameOver = true;
            foreach(BoxCollider2D collider in GetComponents<BoxCollider2D>())
            {
                collider.enabled = false;
                StartCoroutine(DelayGameOver());
            }
        }
    }

    IEnumerator DelayGameOver()
    {
        yield return new WaitForSeconds(1f);
        GC.GameOver();
    }
}
