namespace weather_monitoring_and_reporting_service.models.Bots.Factories;

public class SnowBotFactory : IBotFactory
{
    public Bots CreateBot(BotsConfig botConfiguration)
    {
        return new SnowBot(botConfiguration.SnowBot.TemperatureThreshold, botConfiguration.SunBot.Enabled,
            botConfiguration.SunBot.Message);
    }
}