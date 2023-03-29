using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayWeatherData : MonoBehaviour
{
    List<TextMeshProUGUI> _txtData = new List<TextMeshProUGUI>();

    public void Display(CityWeatherData data)
    {
        foreach (TextMeshProUGUI child in GetComponentsInChildren<TextMeshProUGUI>())
            _txtData.Add(child);

        _txtData[0].SetText(_txtData[0].text + data.cityName);

        _txtData[1].SetText(_txtData[1].text + data.temperature.ToString("f0"));
        _txtData[2].SetText(_txtData[2].text + char.ToUpper(data.description[0]) + data.description.Substring(1) );
        
    }
}
