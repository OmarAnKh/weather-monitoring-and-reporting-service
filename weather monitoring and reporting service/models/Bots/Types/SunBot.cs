using System.Text.Json.Serialization;
using weather_monitoring_and_reporting_service.models.Bots.Conditions;

namespace weather_monitoring_and_reporting_service.models.Bots.Types{

[method: JsonConstructor]

public class SunBot(bool enabled, decimal temperatureThreshold, string? message)
    : Bot(enabled, message, new AboveTemperatureThresholdCheckCondition(temperatureThreshold))
{
    [JsonPropertyName("TemperatureThreshold")]
    public decimal TemperatureThreshold { get; set; }

}
}