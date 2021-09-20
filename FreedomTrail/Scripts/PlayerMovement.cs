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

    public float _sensitivity = 0.7f;
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
        if (Input.GetMouseButton(0))
        {
            if (_isRotating) {
                // offset
                _mouseOffset = (Input.mousePosition - _mouseReference);

                // apply rotation
                _rotation.y = (_mouseOffset.x) * _sensitivity;
                _rotation.z = -(_mouseOffset.y) * _sensitivity;                
                // rotate
                transform.eulerAngles += _rotation;

                var x = transform.eulerAngles;
                float angle = x.z;
                angle = (angle > 180) ? angle - 360 : angle;
                x.z = Mathf.Clamp(angle, -19, 10);               
                transform.eulerAngles = x;
                
                // store new mouse position
                _mouseReference = Input.mousePosition;
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            _isRotating = true;
            _mouseReference = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            _isRotating = false;
        }
    }
}
