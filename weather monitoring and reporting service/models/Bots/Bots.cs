using System.Text.Json.Serialization;
using weather_monitoring_and_reporting_service.models.Weather;

namespace weather_monitoring_and_reporting_service.models.Bots;

public abstract class Bots
{
    [JsonPropertyName("Enabled")] public bool Enabled { get; set; }

    [JsonPropertyName("Message")] public string? Message { get; set; }

    protected Bots(bool enabled, string? message)
    {
        Enabled = enabled;
        Message = message;
    }

    public abstract bool CheckForConditions(IWeather?  weather);
}