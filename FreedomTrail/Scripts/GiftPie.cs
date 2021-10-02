using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiftPie : MonoBehaviour
{
    public Image pivArrow;
    public float angle;
    public int multScore;
    private bool x , clicked;
    private void Start()
    {
        angle = -50;
    }
    private void StateScore()
    {
        if(angle > 40)
        {
            multScore = 2;
        }
        if (angle >= 15 && angle <= 30)
        {
            multScore = 3;
        }
        if (angle >= -12 && angle <= 10)
        {
            multScore = 4;
        }
        if (angle >= -34 && angle <= -15)
        {
            multScore = 6;
        }
        if (angle < -40)
        {
            multScore = 8;
        }
    }
    void Update()
    {
        StateScore();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            clicked = true;
        }
        if (!clicked)
        {
            if (angle >= 50)
            {
                x = true;
            }
            if (angle <= -50)
            {
                x = false;
            }
            //
            if (x)
            {
                angle -= 8;
            }
            else
            {
                angle += 8;
            }
            //angle = Mathf.Clamp(angle, -50, 50);
            pivArrow.rectTransform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
