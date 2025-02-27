using System.Text.Json;
using Newtonsoft.Json;
using weather_monitoring_and_reporting_service.models.Bots.Factories;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace weather_monitoring_and_reporting_service.models.Bots;

public class GetConfigs : IGetConfigs
{
    private static readonly RainBotFactory RainBotFactory = new();
    private static readonly SunBotFactory SunBotFactory = new();
    private static readonly SnowBotFactory SnowBotFactory = new();

    public static List<Bots> LoadFromJsonFile(string path)
    {
        var fileStream = File.ReadAllText(path);
        var options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = null
            
        };
        var config = JsonSerializer.Deserialize<BotsConfig>(fileStream,options);
        if (config is null)
        {
            throw new FileNotFoundException($"No config file found at {path}");
        }

        List<Bots> bots =
        [
            RainBotFactory.CreateBot(config),
            SunBotFactory.CreateBot(config),
            SnowBotFactory.CreateBot(config)
        ];
        return bots;
    }
}