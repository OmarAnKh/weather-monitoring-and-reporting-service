using weather_monitoring_and_reporting_service.models.Weather.Adapters;

namespace weather_monitoring_and_reporting_service.models.Weather.Parsers
{
    public class XmlParserFactory : IWeatherParserFactory
    {
        public IParser CreateParser()
        {
            return new XmlToWeatherAdapter();
        }
    }
}