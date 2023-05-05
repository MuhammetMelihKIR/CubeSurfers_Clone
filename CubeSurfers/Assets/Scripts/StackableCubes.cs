using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackableCubes : MonoBehaviour
{
    private bool _isStack;
    float index;
    public Picker picker;
    
    
    void Start()
    {
        
        _isStack = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.localRotation= new Quaternion(0,0,0,0);
        if (_isStack==true)
        {
            if (transform.parent != null)
            {
                transform.localPosition = new Vector3(0, -index, 0);
            }
           
        }
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "obstacle" && picker.height > 0) 
        {
            picker.DecreaseHeight();
            transform.parent = null;
            GetComponent<BoxCollider>().enabled = false;
            other.gameObject.GetComponent<BoxCollider>().enabled = false;
   
        }

    }
   
    public bool GetIsStack() 
    { 
        return _isStack;

    }
    public void StackOn() 
    {
        _isStack= true;
    }
    public void Index(float index)    
    { 
        this.index = index;
    }
}
