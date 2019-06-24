using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguMover : MonoBehaviour {
    [HideInInspector] public bool facingRight = true;
    [HideInInspector] public bool jump = false;
    public float moveForce = 100f;
    public float maxSpeed = 5f;
    public float jumpForce = 1000f;
    public Transform groundCheck;
    public Transform sideGround;
    public string jumpButton = "Jump";
    public string horizontalCtrl = "Horizontal";
    public string DrunkAxisToggle = "DrunkAxisToggle";

    private bool grounded = false;
    private bool sideGrounded = false;
    private Animator anim;
    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start () {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() {
       
    }
    void FixedUpdate()
    {
            float h = Input.GetAxis(horizontalCtrl);


            if (h * rb2d.velocity.x < maxSpeed)
                rb2d.AddForce(Vector2.right * h * moveForce);


            //Basic Momentum Functions
            if (Mathf.Abs(rb2d.velocity.x) > maxSpeed) 
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);

            if (h > 0 && !facingRight)
                Flip();
            else if (h < 0 && facingRight)
                Flip();

        }
        void OnTriggerEnter2D(Collider2D other)
    {
            if (other.gameObject.CompareTag("FinishFish4"))
            {
                //Coin Pickup
                Destroy(other.gameObject);
            }
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

