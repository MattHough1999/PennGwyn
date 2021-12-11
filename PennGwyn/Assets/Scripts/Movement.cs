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
    float maxSpeed = 1;

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
       
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            rb.velocity = new Vector2(0.0f, 5.0f);
            grounded = false;
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            rend.flipX = false;
            rb.velocity = new Vector2(-2.0f, rb.velocity.y);

        }
        if (Input.GetKey(KeyCode.D))
        {
            rend.flipX = true;
            rb.velocity = new Vector2(2.0f, rb.velocity.y);

        }
        if (Input.GetKeyDown(KeyCode.S)) 
        {
            sliding = true;
            boxSliding.enabled = true;
            boxStanding.enabled = false;
            rb.velocity = new Vector2(rb.velocity.x * 4, rb.velocity.y);
            rend.sprite = SpriteSlide;


        }
        if (Input.GetKeyUp(KeyCode.S)) { sliding = false; }
        if (sliding == false) 
        {
            rend.sprite = SpriteStand;
            boxStanding.enabled = true;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor") grounded = true;
        
    }
}
