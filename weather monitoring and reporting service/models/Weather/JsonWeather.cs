namespace weather_monitoring_and_reporting_service.models.Weather;

public class JsonWeather(string location, decimal temperature, decimal humidity) : Weather(location, temperature, humidity)
{
    
}