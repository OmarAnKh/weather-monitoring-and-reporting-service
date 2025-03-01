using System.Text.Json.Serialization;

namespace weather_monitoring_and_reporting_service.models.Bots;

public abstract class Bot
{
    [JsonPropertyName("Enabled")] public bool Enabled { get; set; }

    [JsonPropertyName("Message")] public string? Message { get; set; }

    protected Bot(bool enabled, string? message)
    {
        Enabled = enabled;
        Message = message;
    }

    public abstract bool CheckForConditions(Weather.Weather?  weather);
}