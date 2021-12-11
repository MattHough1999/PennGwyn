using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.IO;
using UnityEngine.Sprites;



[RequireComponent(typeof(Rigidbody2D))]


public class Movement : MonoBehaviour
{
    private SpriteRenderer rend;

    public BoxCollider2D boxStanding;
    public BoxCollider2D boxSliding;
    public Sprite SpriteStand;
    public Sprite SpriteSlide;
    Rigidbody2D rb = new Rigidbody2D();
    bool moving = false;
    bool grounded = true;
    bool sliding = false;
    public Vector2 MoveDir = Vector2.zero;
    public Vector2 vel = Vector2.zero;
    float maxSpeed = 2.04f;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MoveDir = new Vector2(0, 0);
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.S) && rb.velocity.x < maxSpeed && rb.velocity.x > 0.1) )
        {
            Debug.Log("sliding1");
            boxSliding.enabled = true;
            boxStanding.enabled = false;

            rend.sprite = SpriteSlide;
            if (sliding == false && rb.velocity.x !=0) { Debug.Log("sliding2"); rb.velocity = new Vector2(rb.velocity.x * 4, rb.velocity.y); }
            sliding = true;

        }
        else if ((Input.GetKey(KeyCode.S) && rb.velocity.x > -maxSpeed && rb.velocity.x < -0.1))
        {
            Debug.Log("sliding1");
            boxSliding.enabled = true;
            boxStanding.enabled = false;

            rend.sprite = SpriteSlide;
            if (sliding == false && rb.velocity.x != 0) { Debug.Log("sliding2"); rb.velocity = new Vector2(rb.velocity.x * 4, rb.velocity.y); }
            sliding = true;

        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.velocity = new Vector2(0.0f, 5.0f);
            grounded = false;
            
        }
        if (Input.GetKey(KeyCode.A) && rb.velocity.x > -2.04f)
        {
            rend.flipX = true;
            rb.velocity = new Vector2(-2.0f, rb.velocity.y);

        }
        if (Input.GetKey(KeyCode.D) && rb.velocity.x < 2.04f)
        {
            rend.flipX = false;
            rb.velocity = new Vector2(2.0f, rb.velocity.y);

        }
        
        if (Input.GetKeyUp(KeyCode.S)) { sliding = false; }
        if (sliding == false) 
        {
            rend.sprite = SpriteStand;
            boxStanding.enabled = true;
        }

        //Debug.Log(rb.velocity.x);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor") grounded = true;
        
    }
}
