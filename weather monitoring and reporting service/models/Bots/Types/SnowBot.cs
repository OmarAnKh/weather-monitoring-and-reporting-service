using System.Text.Json.Serialization;
using weather_monitoring_and_reporting_service.models.Bots.Conditions;

namespace weather_monitoring_and_reporting_service.models.Bots.Types{

[method: JsonConstructor]

public class SnowBot(bool enabled, decimal temperatureThreshold, string? message)
    : Bot(enabled, message, new BelowTemperatureThresholdCheckCondition(temperatureThreshold))
{
    [JsonPropertyName("TemperatureThreshold")]
    public decimal TemperatureThreshold { get; set; }

}}