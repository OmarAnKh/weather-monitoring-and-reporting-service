namespace weather_monitoring_and_reporting_service.models.Weather;

public class JsonParserFactory:IWeatherParserFactory
{
    public IParser CreateParser()
    {
        return new JsonToWeatherAdapter();
    }
}