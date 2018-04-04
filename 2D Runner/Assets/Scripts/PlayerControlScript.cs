using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlScript : MonoBehaviour {
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    public float speed;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool onGround;
    private bool jump = true;
    public Sprite sadFace;

    public AudioSource jumpSound;
    public AudioSource dieSound;
    public AudioSource coinTake;


    // Use this for initialization
    void Start () {

        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        rb.velocity = new Vector2(speed, rb.velocity.y);
        //Check if the player is on the ground, if so, set jump to true
        onGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        if (onGround)
        {
            jump = true;
        }

        //jump
        if (Input.GetMouseButtonDown(0) && jump)
        {
            jumpSound.Play();
            rb.velocity = new Vector2(rb.velocity.x, 7);

            if (!onGround)
            {
                jump = false;
            }
        }
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
            coinTake.Play();
        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            sr.sprite = sadFace;
            dieSound.Play();
            Time.timeScale = 0;
        }
    }
}
