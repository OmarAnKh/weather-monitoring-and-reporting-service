using Newtonsoft.Json;

namespace weather_monitoring_and_reporting_service.models.Weather;

public class JsonToWeatherAdapter : IParser
{
    public Weather Parse(string? weather)
    {
        if (weather == null)
        {
            throw new ArgumentNullException(nameof(weather));
        }


        Weather data = JsonConvert.DeserializeObject<Weather>(weather) ??
                       throw new ArgumentException("Invalid JSON data");
        return data;
    }
}