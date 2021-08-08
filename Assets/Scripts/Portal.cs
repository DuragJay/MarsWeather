using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;




public class Portal : MonoBehaviour
{
    public GameObject terrain;
    public Material[] materials;
    public Transform transDevice;

    private bool wasInFront;
    bool insidePortal;
    private void Start()
    {
        setMat(false);
       
    }

    void setMat(bool fullRender)
    {
        var stencilTest = fullRender ? CompareFunction.NotEqual : CompareFunction.Equal;
        foreach (var mat in materials)
        {
            mat.SetInt("_StencilTest", (int)stencilTest);
        }
    }
    private bool getIsInFront()
    {
        Vector3 pos = transform.InverseTransformPoint(transDevice.position);
        return pos.z >= 0 ? true : false;
            
    }
    private void OnTriggerEnter(Collider other)
    {
       
        wasInFront = getIsInFront();
    }
    private void OnTriggerStay(Collider other)
    {
       
        if(!other.CompareTag ("MainCamera"))
        {
            return;
        }
      
        bool IsInFront = getIsInFront();

        if(IsInFront && !wasInFront || wasInFront && !IsInFront)
        {
            insidePortal = !insidePortal;
            terrain.layer = 7;
            setMat(insidePortal);
        }
        if (other.CompareTag("MainCamera") && other.transform.position.z > this.gameObject.transform.position.z)
        {
            terrain.layer = 1;
            print(terrain.layer);
            foreach (var mat in materials)
            {
                mat.SetInt("_StencilTest", (int)CompareFunction.NotEqual);
            }
        }

        wasInFront = IsInFront;
    }
    void onDestroy()
    {
        setMat(true);
    }

}