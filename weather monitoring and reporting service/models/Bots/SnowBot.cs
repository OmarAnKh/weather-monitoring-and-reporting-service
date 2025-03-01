
namespace weather_monitoring_and_reporting_service.models.Bots;

public class SnowBot(decimal temperatureThreshold, bool enabled, string? message)
    : Bot(enabled, message)
{
    public decimal TemperatureThreshold { get; set; } = temperatureThreshold;


    public override bool CheckForConditions(Weather.Weather? weather)
    {
        if (weather?.Temperature < TemperatureThreshold)
        {
            this.Enabled = true;
            Console.WriteLine("SnowBot activated!");
            Console.WriteLine($"SnowBot: {this.Message}\n");
            return true;
        }

        return false;
    }
}