using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.IO;
using UnityEngine.Networking;

public class MarsWeather : MonoBehaviour
{
    public string jSonUrl = "https://mars.nasa.gov/rss/api/?feed=weather&category=msl&feedtype=json";

     
    private void Start()
    {
        StartCoroutine(getData());
    }

    IEnumerator getData()
    {
        
        WWW _www = new WWW(jSonUrl);
        yield return _www;
        if (_www.error == null)
        {
            processJsonData(_www.text);
        }
        else
        {
            print("error");
        }
    }
    private void processJsonData(string url)
    {
        Weather jsonWeather = JsonUtility.FromJson<Weather>(url);

        
        foreach(soleList x in jsonWeather.soles)
        {
            print(x.max_temp);
        }
    }
}

