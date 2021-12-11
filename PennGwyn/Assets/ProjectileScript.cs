using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{

    Rigidbody2D rig;
    void Awake()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    /// <summary>
    /// Message that is called before the first frame update
    /// </summary>
    void Start()
    {
      
    }
}
