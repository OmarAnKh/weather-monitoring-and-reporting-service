using Newtonsoft.Json;

namespace weather_monitoring_and_reporting_service.models.Weather;

public class JsonToWeatherAdapter : IParser
{
    public Weather? Parse(string? weather)
    {
        if (weather == null)
        {
            throw new ArgumentNullException(nameof(weather));
        }

        Weather data;
        try
        {
            data = JsonConvert.DeserializeObject<Weather>(weather) ??
                   throw new ArgumentException("Invalid JSON data");
        }
        catch (Exception e)
        {
            Console.WriteLine($"Unable to parse JSON data: {e.Message}");
            return null;
        }

        return data;
    }
}