namespace weather_monitoring_and_reporting_service.models.Weather
{
    public class Client
    {
        
        private readonly IWeatherParserFactory _parserFactory;

        public Client(IWeatherParserFactory parserFactory)
        {
            _parserFactory = parserFactory;
        }

        public void DisplayWeatherInfo(string data)
        {
            IWeather weather = _parserFactory.CreateParser(data);
            Console.WriteLine($"Location: {weather.Location}, Temperature: {weather.Temperature}, Humidity: {weather.Humidity}");
        }
    }
}