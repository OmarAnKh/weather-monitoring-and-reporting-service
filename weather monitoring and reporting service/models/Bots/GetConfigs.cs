using System.Text.Json;
using weather_monitoring_and_reporting_service.models.Bots.Factories;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace weather_monitoring_and_reporting_service.models.Bots;

public class GetConfigs : IGetConfigs
{
    public List<Bot> LoadFromJsonFile(string path)
    {
        string jsonContent = File.ReadAllText(path);

        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = null
        };

        BotsConfig? config = JsonSerializer.Deserialize<BotsConfig>(jsonContent, options);

        if (config is null)
        {
            throw new FileNotFoundException($"No config file found at {path}");
        }

        return [config.RainBot, config.SunBot, config.SnowBot];
    }
}