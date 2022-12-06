using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
            
    }

}
