using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class IntoThePortal : MonoBehaviour
{
    public GameObject terrain;
    public Material mySkyBox;
    private void Start()
    {
        print(terrain.layer);
        RenderSettings.skybox = mySkyBox;
    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera") && other.transform.position.z > this.gameObject.transform.position.z)
        {
            terrain.layer = 1;
            print(terrain.layer);

            RenderSettings.skybox = mySkyBox;
        }

        if(other.CompareTag("MainCamera") && other.transform.position.z < this.gameObject.transform.position.z)
        {
            terrain.layer = 7;
            print(terrain.layer);
        }

       


    }
    
} 

