using System.Collections;
using System.Collections.Generic;
using System.Data;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class Picker : MonoBehaviour
{
    public GameObject mainCube;
    public float height;
    public Score score;
    [SerializeField]
    private AudioSource takeCube, takeGold ;
    public Movement movement;
    public GameObject winPanel;
    public GameObject restartPanel;
    public ParticleSystem goldPart;
    public ParticleSystem cubePart;
    
    

    private void Start()
    {
       
        height = 0;
      
      winPanel.SetActive(false);
    }
    void Update()
    {
        mainCube.transform.position = new Vector3(transform.position.x, height+1, transform.position.z);
        transform.localPosition = new Vector3(0, -height, 0);
    }
    public void DecreaseHeight()
    {
        
        height-=1;
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("stackable") && other.gameObject.GetComponent<StackableCubes>().GetIsStack() == false)
        {
            takeCube.Play();
            height+=1;
            other.gameObject.GetComponent<StackableCubes>().StackOn();
            other.gameObject.GetComponent<StackableCubes>().Index(height);
            other.gameObject.transform.parent = mainCube.transform;
            cubePart.Play();    
          
        }

        if (other.gameObject.CompareTag("gold"))
        { 
           goldPart.Play();
           takeGold.Play();
           score.Scored(); 

        }
        if (other.gameObject.CompareTag("finish"))
        {
            movement.NotForward();
            winPanel.SetActive(true);
     
        }
        if (other.gameObject.CompareTag("obstacle") && height ==0)
        {
          //  Debug.Log("game over");
            restartPanel.SetActive(true);
            movement.NotForward();
        }
       

    }

}
