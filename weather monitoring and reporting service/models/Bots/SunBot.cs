
namespace weather_monitoring_and_reporting_service.models.Bots;

public class SunBot(decimal temperatureThreshold, bool enabled, string? message)
    : Bot(enabled, message)
{
    public decimal TemperatureThreshold { get; set; } = temperatureThreshold;


    public override bool CheckForConditions(Weather.Weather? weather)
    {
        if (weather?.Temperature > TemperatureThreshold)
        {
            this.Enabled = true;
            Console.WriteLine("SunBot activated!");
            Console.WriteLine($"SunBot: {this.Message}\n");
            return true;
        }

        return false;
    }
}