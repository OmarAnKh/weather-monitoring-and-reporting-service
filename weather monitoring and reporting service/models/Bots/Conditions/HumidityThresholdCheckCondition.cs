namespace weather_monitoring_and_reporting_service.models.Bots.Conditions
{
    public class HumidityThresholdCheckCondition : ICheckConditionBehavior
    {

        public decimal HumidityThreshold { get; }

        public HumidityThresholdCheckCondition(decimal humidityThreshold)
        {
            HumidityThreshold = humidityThreshold;
        }

        public bool CheckForConditions(Weather.Weather? weather)
        {
            return weather?.Humidity > HumidityThreshold;
        }
    }
}