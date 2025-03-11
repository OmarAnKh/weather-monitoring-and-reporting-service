namespace weather_monitoring_and_reporting_service.models.Weather.Parsers
{
    public interface IWeatherParserFactory
    {
        public IParser CreateParser();
    }
}