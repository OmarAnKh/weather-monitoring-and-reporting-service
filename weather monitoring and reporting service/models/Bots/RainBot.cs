using System.Text.Json.Serialization;

namespace weather_monitoring_and_reporting_service.models.Bots;

[method: JsonConstructor]
public class RainBot(bool enabled, decimal humidityThreshold, string? message)
    : Bot(enabled, message, new HumidityThresholdCheckCondition(humidityThreshold))
{
    
    [JsonPropertyName("HumidityThreshold")]
    public decimal HumidityThreshold { get; set; }
}