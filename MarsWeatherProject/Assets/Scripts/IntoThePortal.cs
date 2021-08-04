using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class IntoThePortal : MonoBehaviour
{
    public GameObject terrain;
    private void Start()
    {
       
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.name !="Main Camera")
        {
            return;
        }
        if(transform.position.z > other.transform.position.z)
        {
            print("Outside");

            terrain.layer = 7;
            
        }
        else
        {
            print("Inside Portal");

            terrain.layer = 1;
        }


    }
    
} 

