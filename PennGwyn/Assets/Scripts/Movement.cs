using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.IO;



[RequireComponent(typeof(Rigidbody2D))]


public class Movement : MonoBehaviour
{
    Rigidbody2D rb = new Rigidbody2D();
    bool moving = false;
    public Vector2 MoveDir = Vector2.zero;
    public Vector2 vel = Vector2.zero;
    float maxSpeed = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MoveDir = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(0.0f, 5.0f);
            
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-2.0f, 0.0f);

        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(2.0f, 0.0f);

        }
        
    }
}
