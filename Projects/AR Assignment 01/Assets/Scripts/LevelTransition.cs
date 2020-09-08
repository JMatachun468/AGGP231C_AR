using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class LevelTransition : MonoBehaviour
{
    Touch touch;
    void Start()
    {
        
    }
    void Update()
    { 

        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
