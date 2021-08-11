using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
public class IntoThePortal : MonoBehaviour
{
    public GameObject terrain;
    public Material[] materials;
    private void Start()
    {
        foreach (var mat in materials)
        {
            mat.SetInt("_StencilTest", (int)CompareFunction.Equal);
        }
        Weather w = MarsWeather.getMarsWeather();

        print(w.temp);

    }


    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("MainCamera") && other.transform.position.z > this.gameObject.transform.position.z)
        {
            terrain.layer = 1;
            print(terrain.layer);
            foreach (var mat in materials)
            {
                mat.SetInt("_StencilTest", (int)CompareFunction.NotEqual);
            }
        }

        if (other.CompareTag("MainCamera") && other.transform.position.z < this.gameObject.transform.position.z)
        {
            terrain.layer = 7;
            print(terrain.layer);
            foreach (var mat in materials)
            {
                mat.SetInt("_StencilTest", (int)CompareFunction.Equal);
            }
        }

    }
}