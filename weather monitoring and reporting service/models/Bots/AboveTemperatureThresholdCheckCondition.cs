namespace weather_monitoring_and_reporting_service.models.Bots
{
    public class AboveTemperatureThresholdCheckCondition : ICheckConditionBehavior
    {
        public decimal TemperatureThreshold { get; }

        public AboveTemperatureThresholdCheckCondition(decimal temperatureThreshold)
        {
            TemperatureThreshold = temperatureThreshold;
        }

        public bool CheckForConditions(Weather.Weather? weather)
        {
            return weather?.Temperature > TemperatureThreshold;
        }
    }
}