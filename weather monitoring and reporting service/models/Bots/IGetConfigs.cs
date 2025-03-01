namespace weather_monitoring_and_reporting_service.models.Bots;

public interface IGetConfigs
{
    public List<Bot> LoadFromJsonFile(string path);
}