using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turbine : MonoBehaviour
{
    public GameObject Deathaffect;
    SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("AHAHAH");
        if (collision.transform.tag == "Bullet")
        {
            StartCoroutine(DEATH());
        }
    }


    IEnumerator DEATH()
    {

        rend.color = new Color(0, 0, 0);
        GameObject death = Instantiate(Deathaffect);
        death.transform.position = transform.position;
        death.transform.rotation = death.transform.rotation;
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
