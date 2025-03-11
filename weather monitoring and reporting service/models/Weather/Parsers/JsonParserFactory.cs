using weather_monitoring_and_reporting_service.models.Weather.Adapters;

namespace weather_monitoring_and_reporting_service.models.Weather.Parsers{

public class JsonParserFactory:IWeatherParserFactory
{
    public IParser CreateParser()
    {
        return new JsonToWeatherAdapter();
    }
}
}