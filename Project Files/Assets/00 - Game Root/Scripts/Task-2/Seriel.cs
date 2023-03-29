using System;


[Serializable]
public class OpenWeatherResponse
{
    public MainData main;
    public WeatherData[] weather;
}

[Serializable]
public class MainData
{
    public float temp;
}

[Serializable]
public class WeatherData
{
    public string description;
}

public class CityWeatherData
{
    public string cityName;
    public float temperature;
    public string description;


}
