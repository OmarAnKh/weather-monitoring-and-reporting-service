namespace weather_monitoring_and_reporting_service.models.Bots.Factories;

public interface IBotFactory
{
    Bot CreateBot(BotsConfig botConfiguration);
}