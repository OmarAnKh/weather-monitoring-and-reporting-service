using weather_monitoring_and_reporting_service.models.Bots;
using weather_monitoring_and_reporting_service.models.Weather;

namespace weather_monitoring_and_reporting_service.models
{
    public class WeatherBots
    {
        private readonly IGetConfigs _getConfigs;
        private readonly IWeatherParserFactory _weatherParserFactory;
        private readonly List<Bot> _bots;

        public WeatherBots(IGetConfigs getConfigs, IWeatherParserFactory weatherParserFactory, string botsConfigurationFilePath)
        {
            _getConfigs = getConfigs;
            _weatherParserFactory = weatherParserFactory;
            _bots = _getConfigs.LoadFromJsonFile(botsConfigurationFilePath) ?? new List<Bot>();
        }

        public void CheckWeatherBots(string? data)
        {
            IParser weatherDataParser = new Client(_weatherParserFactory).GetParser();
            _bots.Where(bot => bot.Enabled)
                .ToList()
                .ForEach(bot => bot.CheckForConditions(weatherDataParser.Parse(data)));
        }
    }
}