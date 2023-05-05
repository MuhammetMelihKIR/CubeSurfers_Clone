using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gold : MonoBehaviour
{
    private int _goldCount;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { 
        transform.Rotate(new Vector3(0, 100, 0)*Time.deltaTime);
        
    }

    private void OnTriggerEnter(Collider other)
    {
       if( other.tag == "picker")
        {
            DestroyGold();
            
            
        }
    }

    public void DestroyGold()
    {
        Destroy(gameObject);
    }

}
