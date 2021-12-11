using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.IO;



[RequireComponent(typeof(Rigidbody2D))]


public class MovementSeb : MonoBehaviour
{
    Rigidbody2D rb = new Rigidbody2D();
    bool moving = false;
    public Vector2 MoveDir = Vector2.zero;
    public Vector2 vel = Vector2.zero;
    float maxSpeed = 1;
    float lastAKeyInputtedTime;
    float lastDKeyInputtedTime;
    float dodgeCooldown;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MoveDir = new Vector2(0, 0);

        lastAKeyInputtedTime = Time.time;
        lastDKeyInputtedTime = Time.time;
        dodgeCooldown = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //Jump
        {
            rb.velocity = new Vector2(rb.velocity.x, 5.0f);

        }

        if ((Time.time - dodgeCooldown) > 1.0f)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKeyDown(KeyCode.A))
            {
                float currentKeyInputtedTime = Time.time;
                if (Input.GetKeyDown(KeyCode.A)) //Dodge
                {
                    if (((currentKeyInputtedTime - lastAKeyInputtedTime) < 0.5f)/* && ((Time.time - dodgeCooldown) > 1.0f)*/)
                    {
                        Debug.LogError("Dodged Left");
                        //rb.velocity = new Vector2(-640.0f, 0.0f);

                        Vector2 impulseMagnitude = new Vector2(-4f, rb.velocity.y);
                        rb.AddForce(impulseMagnitude, ForceMode2D.Impulse);
                        dodgeCooldown = Time.time;
                        //GetComponent<Rigidbody2D>().AddForce(impulseMagnitude, ForceMode2D.Impulse);
                    }
                }
                else if (Input.GetKey(KeyCode.LeftShift)) //Sprint
                {
                    rb.velocity = new Vector2(-4.0f, rb.velocity.y);
                }
                else //Walk
                {
                    rb.velocity = new Vector2(-2.0f, rb.velocity.y);
                }
                lastAKeyInputtedTime = currentKeyInputtedTime;
            }
            if (Input.GetKey(KeyCode.D) || Input.GetKeyDown(KeyCode.D))
            {
                float currentKeyInputtedTime = Time.time;
                if (Input.GetKeyDown(KeyCode.D)) //Dodge
                {
                    if (((currentKeyInputtedTime - lastDKeyInputtedTime) < 0.5f)/* && ((Time.time - dodgeCooldown) > 1.0f)*/)
                    {
                        Debug.LogError("Dodged Right");
                        //rb.velocity = new Vector2(640.0f, 0.0f);

                        Vector2 impulseMagnitude = new Vector2(4f, rb.velocity.y);
                        rb.AddForce(impulseMagnitude, ForceMode2D.Impulse);
                        dodgeCooldown = Time.time;
                        //GetComponent<Rigidbody2D>().AddForce(impulseMagnitude, ForceMode2D.Impulse);
                    }
                }
                else if (Input.GetKey(KeyCode.LeftShift)) //Sprint
                {
                    rb.velocity = new Vector2(4.0f, rb.velocity.y);
                }
                else //Walk
                {
                    rb.velocity = new Vector2(2.0f, rb.velocity.y);
                }
                lastDKeyInputtedTime = currentKeyInputtedTime;
            }
        }
    }
}
