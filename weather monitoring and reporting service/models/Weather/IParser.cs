namespace weather_monitoring_and_reporting_service.models.Weather
{
    public interface IParser
    {
        public Weather? Parse(string? weather);
    }
}