using System.Text.Json.Serialization;
using weather_monitoring_and_reporting_service.models.Weather;

namespace weather_monitoring_and_reporting_service.models.Bots;

public class RainBot : Bots
{
    public decimal HumidityThreshold { get; set; }

    [JsonConstructor]
    public RainBot(bool enabled, decimal humidityThreshold, string? message)
        : base(enabled, message)
    {
        HumidityThreshold = humidityThreshold;
    }

    public override bool CheckForConditions(IWeather? weather)
    {
        if (this.HumidityThreshold > weather?.Humidity)
        {
            Console.WriteLine("RainBot activated!");
            Console.WriteLine($"RainBot: {this.Message}");
            return true;
        }

        return false;
    }
}