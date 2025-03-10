
using System.Text.Json.Serialization;

namespace weather_monitoring_and_reporting_service.models.Bots;

[method: JsonConstructor]

public class SunBot(bool enabled, decimal temperatureThreshold, string? message)
    : Bot(enabled, message, new AboveTemperatureThresholdCheckCondition(temperatureThreshold))
{
    [JsonPropertyName("TemperatureThreshold")]
    public decimal TemperatureThreshold { get; set; }

}