namespace weather_monitoring_and_reporting_service.models.Weather
{
    public class XmlParserFactory:IWeatherParserFactory
    {

        public IWeather CreateParser(string data)
        {
            return new XmlToWeatherAdapter(data);
        }
    }
}