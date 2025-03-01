using System.Text.Json.Serialization;

namespace weather_monitoring_and_reporting_service.models.Bots;

public class RainBot : Bot
{
    public decimal HumidityThreshold { get; set; }

    [JsonConstructor]
    public RainBot(bool enabled, decimal humidityThreshold, string? message)
        : base(enabled, message)
    {
        HumidityThreshold = humidityThreshold;
    }

    public override bool CheckForConditions(Weather.Weather? weather)
    {
        if ( weather?.Humidity > this.HumidityThreshold)
        {
            Console.WriteLine("RainBot activated!");
            Console.WriteLine($"RainBot: {this.Message}\n");
            return true;
        }

        return false;
    }
}