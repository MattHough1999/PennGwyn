using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{


    // Raytracing 
    public Transform RayFirePos;
    public float SightRange = 5f;
    private RaycastHit2D ray;
    public LayerMask Mask;
    private float timeLostPlayer = 0;

    // General
    public Transform pos1;
    public Transform pos2;

    public float minDistFromPoint = .15f;
    public float forgetPlayerTime = 1f;

    private SpriteRenderer rend;
    private Vector2 curTarget;
    private float distance;
    private Vector2 lookDirection;
    bool TargetSwitch = false;

    public float RunSpeed = 10f;
    public float NormalSpeed = 5f;

    private bool chasing = false;
    private bool LostPlayer = false;

    private bool isRed = false;
    private Color originalCol;


    // Start is called before the first frame update
    void Start()
    {
        rend = gameObject.GetComponentInChildren<SpriteRenderer>();
        curTarget = pos2.position;
        lookDirection = transform.right;
        originalCol = rend.color;

    }

    // Update is called once per frame
    void Update()
    {
        // get distance
        distance = transform.position.x - curTarget.x;

        // Fire ray
        FireRay();

        if (!chasing)
        {

            if (isRed) { rend.color = originalCol; isRed = false; }

            // If close to the current target and not chasing player, switch target!
            if (Mathf.Abs(distance) < minDistFromPoint)
            {
                if (TargetSwitch) { curTarget = pos2.position; TargetSwitch = false; }
                else { curTarget = pos1.position; TargetSwitch = true; }
            }
        }
        else
        {
            // Chasing target \\


            Debug.Log("Chasing Player");
            // Visual change here.

            if (!isRed) { rend.color = new Color(100, 0, 0); isRed = true; }



            // See if can attack here
            



        }

        MoveEnemy();
    }

    private void FireRay()
    {

        // Check if can see player.
        ray = Physics2D.Raycast(RayFirePos.position, lookDirection, SightRange, Mask);
        Debug.DrawRay(RayFirePos.position, lookDirection * SightRange, Color.red, .1f); if (chasing) { chasing = false; curTarget = pos2.position; }

        if (ray.collider != null)
        {
            //Debug.Log("HIt" + ray.collider.name);
            Debug.DrawRay(RayFirePos.position, lookDirection * ray.distance, Color.red, .1f);

            // check if player
            if (ray.collider.tag == "Player") { curTarget = ray.collider.transform.position; chasing = true; LostPlayer = false; }

            else
            {
                if (chasing)
                {

                    if (LostPlayer)
                    {
                        if (Time.time - timeLostPlayer > forgetPlayerTime)
                        {
                            chasing = false; curTarget = pos2.position;
                            LostPlayer = false;
                        }
                    }
                    else
                    {
                        Debug.Log("Lost Player!");
                        LostPlayer = true;
                        timeLostPlayer = Time.time;
                    }


                }
            }
        }

        else { Debug.DrawRay(RayFirePos.position, lookDirection * SightRange, Color.red, .1f); if (chasing) { chasing = false; curTarget = pos2.position; } }

    }


    public void MoveEnemy()
    {
        if (distance > .1f) { if (transform.localScale.x > 0) { flip(); } }
        else { if (transform.localScale.x < 0) { flip(); } }


        float stepThisFrame = 0;
        if (chasing) { stepThisFrame = RunSpeed * Time.deltaTime; }
        else
        {
            stepThisFrame = NormalSpeed * Time.deltaTime;
        }

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(curTarget.x, transform.position.y, transform.position.z), stepThisFrame);
    }

    private void flip()
    {

        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;

        if (scale.x > 0) { lookDirection = transform.right; }
        else { lookDirection = -transform.right; }

    }
}
