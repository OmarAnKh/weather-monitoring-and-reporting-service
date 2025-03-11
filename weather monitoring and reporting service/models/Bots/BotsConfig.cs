using System.Text.Json.Serialization;
using weather_monitoring_and_reporting_service.models.Bots.Types;

namespace weather_monitoring_and_reporting_service.models.Bots{

public class BotsConfig
{
    [JsonPropertyName("RainBot")] public RainBot RainBot { get; init; }

    [JsonPropertyName("SunBot")] public SunBot SunBot { get; init; }

    [JsonPropertyName("SnowBot")] public SnowBot SnowBot { get; init; }

    [JsonConstructor]
    public BotsConfig(RainBot rainBot, SunBot sunBot, SnowBot snowBot)
    {
        RainBot = rainBot ?? throw new ArgumentNullException(nameof(rainBot));
        SunBot = sunBot ?? throw new ArgumentNullException(nameof(sunBot));
        SnowBot = snowBot ?? throw new ArgumentNullException(nameof(snowBot));
    }
}
}