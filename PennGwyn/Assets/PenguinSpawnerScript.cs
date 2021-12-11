using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinSpawnerScript : MonoBehaviour
{

    public GameObject Penguin;
    public Transform PenguParent;

    private float timeLastPeng = 0;
    public float timeBetweenPeng = 0.5f;
    

    // Start is called before the first frame update
    void Start()
    {
        timeLastPeng = Time.time - timeBetweenPeng;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - timeLastPeng > timeBetweenPeng)
        {
            Debug.Log("PENNNG");
            GameObject pengu = GameObject.Instantiate(Penguin);
            pengu.transform.SetParent(PenguParent);
            pengu.transform.localPosition = new Vector3(Random.Range(-1000, 1000), 715, 0);
            timeLastPeng = Time.time;
        }

        
    }
}
