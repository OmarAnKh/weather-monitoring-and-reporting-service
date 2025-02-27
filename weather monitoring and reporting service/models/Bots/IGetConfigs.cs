namespace weather_monitoring_and_reporting_service.models.Bots;

public interface IGetConfigs
{
    public static abstract List<Bots> LoadFromJsonFile(string path);
}