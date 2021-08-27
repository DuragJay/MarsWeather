using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using System.Net;
using System.IO;
using UnityEngine.Networking;

public class Portal : MonoBehaviour
{
    public GameObject terrain;
    public Material[] materials;
    public Transform transDevice;
    public GameObject uiCircle;

    private bool isInside = false;
    private bool isOutside = false;
    bool wasInFront;
    bool inOtherWorld;
    private void Start()
    {
        setMat(false);
        uiCircle.SetActive(false);
        terrain.layer = 7;


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
        Vector3 playerPost = Camera.main.transform.position + Camera.main.transform.forward * (Camera.main.nearClipPlane * 4);
        Vector3 pos = transform.InverseTransformPoint(playerPost);
        Vector3 myPos = transform.InverseTransformPoint(this.gameObject.transform.position);
        return pos.z >= myPos.z ? true : false;
            
    }
    private void OnTriggerEnter(Collider other)
    {
       
       if(other.transform != transDevice)
        {
            return;
        }
        wasInFront = getIsInFront();
    }
    private void OnTriggerStay(Collider other)
    {
        Vector3 playerPost = Camera.main.transform.position + Camera.main.transform.forward * (Camera.main.nearClipPlane * 4);

      /*  if (transform.InverseTransformPoint(playerPost).z <= 0) ;
        {
            if(isOutside)
            {
                isOutside = false;
                isInside = true;
                terrain.layer = 1;
                uiCircle.SetActive(true);
                setMat(True);
            }
            else
            {
                isOutside = true;
                isInside = false;
                terrain.layer = 7;
                uiCircle.SetActive(false);
                setMat(False);
            }
        }*/


        bool isInFront = getIsInFront();
        if((isInFront && !wasInFront) || (wasInFront && !isInFront))
        {
            inOtherWorld = !inOtherWorld;
            if(inOtherWorld == false)
            {
                terrain.layer = 7;
                uiCircle.SetActive(false);
            }
            else
            {
                terrain.layer = 1;
                uiCircle.SetActive(true);
            }
            setMat(inOtherWorld);
            
        }
        wasInFront = isInFront;
        
    }
   

    void onDestroy()
    {
        setMat(true);
    }

}