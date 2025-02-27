namespace weather_monitoring_and_reporting_service.models.Bots.Factories;

public class RainBotFactory: IBotFactory
{
    public Bots CreateBot(BotsConfig botConfiguration)
    {
        return new RainBot(botConfiguration.RainBot.Enabled, botConfiguration.RainBot.HumidityThreshold, 
            botConfiguration.RainBot.Message);
    }
}