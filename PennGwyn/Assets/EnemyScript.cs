using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform pos1;
    public Transform pos2;

    public float minDistFromPoint = .15f;

    private SpriteRenderer rend;
    private Vector2 curTarget;
    private float distance;
    private Vector2 lookDirection;
    bool TargetSwitch = false;

    public float RunSpeed = 10f;
    public float NormalSpeed = 5f;

    private bool chasing = false;



    // Start is called before the first frame update
    void Start()
    {
        rend = gameObject.GetComponent<SpriteRenderer>();
        curTarget = pos2.position;
        lookDirection = -transform.right;

    }

    // Update is called once per frame
    void Update()
    {
        distance = transform.position.x - curTarget.x;

        if (!chasing)
        {

            // If close to the current target and not chasing player, switch target!
            if (Mathf.Abs(distance) < minDistFromPoint)
            {
                if (TargetSwitch) { curTarget = pos2.position; TargetSwitch = false; }
                else { curTarget = pos1.position; TargetSwitch = true; }
            }
        }
        else
        {
           // Chasing target

           // Visual change here.


            // See if can attack here


        }


        MoveEnemy();


        
       

    }

    public void MoveEnemy()
    {
        if (distance > .1f) { if (transform.localScale.x < 0) { flip(); } }
        else { if (transform.localScale.x > 0) { flip(); } }


        float stepThisFrame = 0;
        if (chasing) { }
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

        if (scale.x > 0) { lookDirection = -transform.right; }
        else { lookDirection = transform.right; }

    }
}
