using Newtonsoft.Json;

namespace weather_monitoring_and_reporting_service.models.Weather;

public class JsonToWeatherAdapter: IWeather
{
    private readonly Weather? _jsonWeather;

    public JsonToWeatherAdapter(string json)
    {
        _jsonWeather=JsonConvert.DeserializeObject<Weather>(json) ?? throw new ArgumentException("Invalid JSON data");

    }
    

    public string? Location
    {
        get=>_jsonWeather?.Location;
        set
        {
            if (_jsonWeather != null)
            {
                _jsonWeather.Location = value;
            }
        }
    }

    public decimal? Temperature {
        get=>_jsonWeather?.Temperature;
        set
        {
            if (_jsonWeather != null)
            {
                _jsonWeather.Temperature = value;
            }
        }
        
    }
    public decimal? Humidity{
        get=>_jsonWeather?.Humidity;
        set
        {
            if (_jsonWeather != null)
            {
                _jsonWeather.Humidity = value;
            }
        } 
    }
}