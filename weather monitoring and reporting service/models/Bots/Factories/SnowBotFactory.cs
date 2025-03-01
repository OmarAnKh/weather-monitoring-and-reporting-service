namespace weather_monitoring_and_reporting_service.models.Bots.Factories;

public class SnowBotFactory : IBotFactory
{
    public Bot CreateBot(BotsConfig botConfiguration)
    {
        return new SnowBot(botConfiguration.SnowBot.TemperatureThreshold, botConfiguration.SnowBot.Enabled,
            botConfiguration.SnowBot.Message);
    }
}