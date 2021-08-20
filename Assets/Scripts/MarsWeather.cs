using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.IO;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class MarsWeather : MonoBehaviour
{
    public string jSonUrl = "https://mars.nasa.gov/rss/api/?feed=weather&category=msl&feedtype=json";
    // Weather Data
    public string sol;
    public string terrestrial_date;

    public  string ls;

    public string season;

    public   string min_temp;

    public  string max_temp;

    public  string pressure;

    public  string pressure_string;

    public  string atmo_opacity;

    public string sunrise;

    public  string sunset;
    /// UI 
    public TextMeshProUGUI textSol;
    public TextMeshProUGUI textMinT;
    public TextMeshProUGUI textMaxT;
    public TextMeshProUGUI textPressure;

    public bool _isActivte;

    string[] _textChar;

    public float _timeInSecounds;

    float _timer;
    int _charCount;

    private void Start()
    {
        StartCoroutine(getData());

        _textChar = new string[textSol.text.Length];
        for (int i = 0; i < textSol.text.Length; i++)
        {
            _textChar[i] = textSol.text.Substring(i, 1);
        }
        textSol.text = "";
        _charCount = 0;
        _timer = 0;


    }
    

   public IEnumerator getData()
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
    public Weather processJsonData(string url)
    {
        Weather jsonWeather = JsonUtility.FromJson<Weather>(url);
        sol = "Sol: " + jsonWeather.soles[0].sol;
        season = "Season: " + jsonWeather.soles[0].season;
        min_temp = "Min Temperature: " + jsonWeather.soles[0].min_temp;
        max_temp = "Max Temperature: " + jsonWeather.soles[0].max_temp;
        pressure = "Pressure: " + jsonWeather.soles[0].pressure;

        //Setting UI to Weather Data
        textSol.text = sol;
        textMaxT.text = min_temp;
        textMinT.text = max_temp;
        textPressure.text = pressure;



        return jsonWeather;

    }
    private void Update()
    {
        if (this.gameObject.layer == 1)
        {
            _isActivte = true;
        }
        if(this.gameObject.layer == 7)
        {
            _isActivte = false;
        }
        if(_isActivte)
        {
            if(_charCount < _textChar.Length)
            {
                _timer += Time.deltaTime;
                if(_timer >= _timeInSecounds)
                {
                    textSol.text += _textChar[_charCount];
                    _charCount++;
                    _timer = 0;
                }
            }
        }
        
    }
}

