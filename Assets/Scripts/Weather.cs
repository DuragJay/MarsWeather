using System;
using System.Collections.Generic;
[System.Serializable]
public class Weather
{
    public List<soleList> soles;

}
[System.Serializable]
public class soleList
{
    public string terrestrial_date;

    public string sol;

    public string ls;

    public string season;

    public string min_temp;

    public string max_temp;

    public string pressure;

    public string pressure_string;

    public string atmo_opacity;

    public string sunrise;

    public string sunset;
}


