using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float forwardSpeed;
    public float rotationSpeed;
    private Rigidbody _rb;
    private float _touchX;
    private float _newX = 0;
    public float limitX;
    

    void Start()
    {
        _rb= GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Rotate();
        MoveForward();
      
        
        
    }
    public void NotForward()
    {
        forwardSpeed = 0;
        rotationSpeed = 0;
        
    }
   

    public void MoveForward()
    {

       
        Vector3 newPosition = new Vector3(_newX, transform.position.y, transform.position.z + forwardSpeed * Time.deltaTime);
        transform.position = newPosition;
    }

    public void Rotate()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            _touchX = Input.GetTouch(0).deltaPosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            _touchX = Input.GetAxis("Mouse X");
        }
        _newX = transform.position.x + rotationSpeed * _touchX * Time.deltaTime;
        _newX = Mathf.Clamp(_newX, -limitX, limitX);
    }
}
