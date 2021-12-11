using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerScript : MonoBehaviour
{
    public void SwitchScene(int SceneToSwitchTo)
    {
       SceneManager.LoadScene(SceneToSwitchTo);
      // SceneChanged(SceneToSwitchTo);
    }
}