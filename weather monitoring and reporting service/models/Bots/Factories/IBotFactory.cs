namespace weather_monitoring_and_reporting_service.models.Bots;

public interface IBotFactory
{
    Bots CreateBot(BotsConfig botConfiguration);
}