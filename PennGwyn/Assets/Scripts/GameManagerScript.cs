using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    public static GameManagerScript GameManager;

    public SceneManagerScript sceneManager;
    



    private void Awake()
    {
        if (GameManager != null)
        {
            Destroy(gameObject);
        }
        else
        {
            GameManager = this;
            DontDestroyOnLoad(this);
        }
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
