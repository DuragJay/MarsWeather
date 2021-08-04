using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class IntoThePortal : MonoBehaviour
{
    public Material[] materials;

    private void Start()
    {
        OnDestroy();
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
            foreach(var mat in materials)
            {
                mat.SetInt("_StencilTest", (int)CompareFunction.Equal);
            }

            
        }
        else
        {
            print("Inside Portal");
            foreach(var mat in materials)
            {
                mat.SetInt("_StencilTest", (int)CompareFunction.NotEqual);
            }

        }


    }
    private void OnDestroy()
    {
        foreach(var mat in materials)
        {
            mat.SetInt("_StencilTest",(int)CompareFunction.NotEqual);
        }

    }
} 

