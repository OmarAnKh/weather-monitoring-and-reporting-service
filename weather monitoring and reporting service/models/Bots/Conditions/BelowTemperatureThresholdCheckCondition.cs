namespace weather_monitoring_and_reporting_service.models.Bots.Conditions
{
    public class BelowTemperatureThresholdCheckCondition: ICheckConditionBehavior
    {
        public decimal TemperatureThreshold { get; }

        public BelowTemperatureThresholdCheckCondition(decimal temperatureThreshold)
        {
            TemperatureThreshold = temperatureThreshold;
        }

        public bool CheckForConditions(Weather.Weather? weather)
        {
            return weather?.Temperature < TemperatureThreshold;
        }
    }

}