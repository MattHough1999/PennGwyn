using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour
{


    public void OnStartClicked()
    {

        GameManagerScript.GameManager.sceneManager.SwitchScene(1);
    }

    public void OnExitClicked()
    {
        Application.Quit();

    }

    public void OnOptionsClicked()
    {

    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
