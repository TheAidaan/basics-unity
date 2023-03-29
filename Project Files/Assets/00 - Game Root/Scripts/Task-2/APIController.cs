using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.Net;
using System.IO;

public class APIController : MonoBehaviour
{
    const string API_KEY = "31a1cc504ab5b8d50240e5512cbf4c00";


    List<CityWeatherData> _weatherDataList = new List<CityWeatherData>();

    GameObject _pnlWeatherData;


    // Start is called before the first frame update
    void Start()
    {
        _pnlWeatherData = Resources.Load<GameObject>("Prefabs/pnlWeatherData");


        GetWeatherDataForAllCities();

    }

    void GetWeatherDataForAllCities()
    {
        StartCoroutine(GetWeatherData("Bhisho"));
        StartCoroutine(GetWeatherData("Bloemfontein"));
        StartCoroutine(GetWeatherData("Johannesburg"));
        StartCoroutine(GetWeatherData("Pietermaritzburg"));
        StartCoroutine(GetWeatherData("Polokwane"));
        StartCoroutine(GetWeatherData("Mbombela"));
        StartCoroutine(GetWeatherData("Kimberley"));
        StartCoroutine(GetWeatherData("Mahikeng"));
        StartCoroutine(GetWeatherData("Cape Town"));
    }

    IEnumerator GetWeatherData(string cityName)
    {
        string url = "https://api.openweathermap.org/data/2.5/weather?q="+ cityName + "&appid=" + API_KEY;

        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log("Could not get weather data for: " +  cityName + "; Error: "+ www.error);
                yield break;
            }

            var json = JsonUtility.FromJson<OpenWeatherResponse>(www.downloadHandler.text);

            float temperature = json.main.temp;
            string description = json.weather[0].description;

            _weatherDataList.Add(new CityWeatherData
            {
                cityName = cityName,
                temperature = temperature,
                description = description

        });

        }

        if (_weatherDataList.Count == 9) 
            Display();
    }

    

    void Display()
    {
        GameObject[,] displayGrid = new GameObject[3,3];

        int x = 0;
        int y = 0;
        
        foreach (CityWeatherData cityweather in _weatherDataList)
        {
            displayGrid[x,y] = Instantiate(_pnlWeatherData, transform);
            displayGrid[x, y].GetComponent<DisplayWeatherData>().Display(cityweather);

            y++;
            if (y > 2)
            {
                x++;
                y = 0;
            }

        }

        for (x=0; x < 3; x++)
        {
            for (y = 0; y < 3; y++)
            {
                float xPos = displayGrid[x, y].GetComponent<RectTransform>().anchoredPosition.x;
                float yPos = displayGrid[x, y].GetComponent<RectTransform>().anchoredPosition.y;

                displayGrid[x, y].GetComponent<RectTransform>().anchoredPosition = new Vector2(xPos * x, yPos * y);
;
            }
        }
    }
}

