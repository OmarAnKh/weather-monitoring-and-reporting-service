using weather_monitoring_and_reporting_service.models.Weather.Parsers;

namespace weather_monitoring_and_reporting_service.models.Weather
{
    public class Client
    {
        private readonly IWeatherParserFactory _parserFactory;

        public Client(IWeatherParserFactory parserFactory)
        {
            _parserFactory = parserFactory;
        }

        public IParser GetParser()
        {
            return _parserFactory.CreateParser();
        }
    }
}