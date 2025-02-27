namespace weather_monitoring_and_reporting_service.models.Weather;

public class XmlWeather(string location, decimal temperature, decimal humidity)
    : Weather(location, temperature, humidity)
{
}