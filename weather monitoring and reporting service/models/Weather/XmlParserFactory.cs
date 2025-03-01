namespace weather_monitoring_and_reporting_service.models.Weather
{
    public class XmlParserFactory:IWeatherParserFactory
    {

        public IParser CreateParser()
        {
            return new XmlToWeatherAdapter();
        }
    }
}