using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScript : MonoBehaviour
{
    BoxCollider2D col;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        StartCoroutine(TempDisable());



    }

    IEnumerator TempDisable()
    {

        yield return new WaitForSeconds(2);
    
        col.isTrigger = true;
        yield return new WaitForSeconds(4);

        col.isTrigger = false;

    }
}
