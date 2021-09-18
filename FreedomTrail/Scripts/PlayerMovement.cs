using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Transform Gun;
    public float x , y;
    public float rotatespeed = 10f;
    private float startingPosition;
    Vector3 rot ;

    private float _sensitivity = 1f;
    private Vector3 _mouseReference;
    private Vector3 _mouseOffset;
    private Vector3 _rotation = Vector3.zero;
    private bool _isRotating;
    private void Start()
    {
        Gun = transform.GetChild(0);
     
    }
    private void Update()
    {
        if (_isRotating)
        {
            // offset
            _mouseOffset = (Input.mousePosition - _mouseReference);

            // apply rotation
            _rotation.y = (_mouseOffset.x ) * _sensitivity;
            _rotation.z = -(_mouseOffset.y) * _sensitivity;
            // rotate
            transform.eulerAngles += _rotation;

            // store new mouse position
            _mouseReference = Input.mousePosition;
        }
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);          
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    _isRotating = true;
                    _mouseReference = Input.mousePosition;
                    break;               
                case TouchPhase.Ended:
                    _isRotating = false;
                    break;
            }
        }       
    }
}
