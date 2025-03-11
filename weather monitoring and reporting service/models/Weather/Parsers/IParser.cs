namespace weather_monitoring_and_reporting_service.models.Weather.Parsers
{
    public interface IParser
    {
        public Weather? Parse(string? weather);
    }
}