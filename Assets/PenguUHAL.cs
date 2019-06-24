using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguUHAL : MonoBehaviour {

    [HideInInspector] public bool facingRight = true;

    public float speed;

    private Rigidbody2D rb2d;
	// Use this for initialization
	void Start () {
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate() {

        float moveHorizontal = Input.GetAxis("Horizontal");


        Vector2 movement = new Vector2(moveHorizontal, 0);

        rb2d.AddForce(movement * speed);
	}
    void Flip()
    {
        //Controls that allow facing left.
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
