namespace weather_monitoring_and_reporting_service.models.Bots
{
    public interface ICheckConditionBehavior
    {
        public bool CheckForConditions(Weather.Weather? weather);

    }
}