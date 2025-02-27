namespace weather_monitoring_and_reporting_service.models.Bots.Factories;

public class SunBotFactory : IBotFactory
{
    public Bots CreateBot(BotsConfig botConfiguration)
    {
        return new SunBot(botConfiguration.SunBot.TemperatureThreshold, botConfiguration.SunBot.Enabled,
            botConfiguration.SunBot.Message);
    }
}