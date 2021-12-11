using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguScript : MonoBehaviour
{

    float timeOfCreation = 0;
    public float DEATHTIME = 7;


    private void Awake()
    {
        timeOfCreation = Time.time;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if (Time.time - timeOfCreation > DEATHTIME)
        {
            Destroy(this);
        }   
    }
}
