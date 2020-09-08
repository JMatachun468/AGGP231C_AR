using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TouchControl : MonoBehaviour
{
    public float timer;
    public float xClamp;
    public float yClamp;
    public Text text;
    bool moveAllowed;
    Collider2D col;
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Time Left: " + Mathf.Round(timer * 100f) / 100;

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            float touchPosX = Mathf.Clamp(touchPosition.x, xClamp*-1, xClamp);
            float touchPosY = Mathf.Clamp(touchPosition.y, yClamp*-1, yClamp);
            if (touch.phase == TouchPhase.Began)
            {
                Collider2D touchedCollider = Physics2D.OverlapPoint(touchPosition);
                if(col == touchedCollider)
                {
                    moveAllowed = true;
                }
            }
            if (touch.phase == TouchPhase.Moved)
            {
                if(moveAllowed)
                {

                    transform.position = new Vector2(touchPosX, touchPosY);
                }
            }
            if (touch.phase == TouchPhase.Ended)
            {
                moveAllowed = false;
            }

        }

        Timer();
    }

    void Timer()
    {
        timer -= Time.deltaTime;

        if(timer < 0)
        {
            SceneManager.LoadScene(3);
        }
    }
}
