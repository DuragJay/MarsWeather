using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.IO;

public class MarsWeather : MonoBehaviour
{
    private static string api_key = "https://api.nasa.gov/insight_weather/?api_key=29mlPS6T8zkNo6wfCUtgA4bBcDNWj5PecXkxUO27&feedtype=json&ver=1.0";
    // Start is called before the first frame update

    public static Weather getMarsWeather()
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(api_key);

        HttpWebResponse response = (HttpWebResponse)request.GetResponse();

        StreamReader reader = new StreamReader(response.GetResponseStream());

        string json = reader.ReadToEnd();

        print(json);
        return JsonUtility.FromJson<Weather>(json);
    }
   
}
