using System.Text.Json.Serialization;
using weather_monitoring_and_reporting_service.models.Bots.Types;

namespace weather_monitoring_and_reporting_service.models.Bots
{
    [method: JsonConstructor]
    public class BotsConfig(RainBot rainBot, SunBot sunBot, SnowBot snowBot)
    {

        [JsonPropertyName("RainBot")]
        public RainBot RainBot { get; init; } = rainBot ?? throw new ArgumentNullException(nameof(rainBot));

        [JsonPropertyName("SunBot")]
        public SunBot SunBot { get; init; } = sunBot ?? throw new ArgumentNullException(nameof(sunBot));

        [JsonPropertyName("SnowBot")]
        public SnowBot SnowBot { get; init; } = snowBot ?? throw new ArgumentNullException(nameof(snowBot));
    }
}