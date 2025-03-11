using weather_monitoring_and_reporting_service.models.Bots;
using weather_monitoring_and_reporting_service.models.Bots.Configs;
using weather_monitoring_and_reporting_service.models.Weather;
using weather_monitoring_and_reporting_service.models.Weather.Parsers;

namespace weather_monitoring_and_reporting_service.models
{
    public class WeatherBots
    {
        private readonly IWeatherParserFactory _weatherParserFactory;
        private readonly List<Bot> _bots;

        public WeatherBots(IGetConfigs getConfigs, IWeatherParserFactory weatherParserFactory, string botsConfigurationFilePath)
        {
            _weatherParserFactory = weatherParserFactory;
            _bots = getConfigs.LoadFromJsonFile(botsConfigurationFilePath);
        }

        public void CheckWeatherBots(string? data)
        {
            IParser weatherDataParser = new Client(_weatherParserFactory).GetParser();
            Weather.Weather? weather = weatherDataParser.Parse(data);

            _bots.Where(bot => bot.Enabled)
                .ToList()
                .ForEach(bot =>
                {
                    bot.Check(weather);
                });
        }
    }
}