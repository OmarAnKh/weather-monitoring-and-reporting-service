namespace weather_monitoring_and_reporting_service.models.Weather;

public interface IWeatherParserFactory
{
    public IParser CreateParser();
}