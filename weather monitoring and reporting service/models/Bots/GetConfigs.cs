using System.Text.Json;
using weather_monitoring_and_reporting_service.models.Bots.Factories;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace weather_monitoring_and_reporting_service.models.Bots;

public class GetConfigs : IGetConfigs
{
    private readonly static RainBotFactory RainBotFactory = new RainBotFactory();
    private readonly static SunBotFactory SunBotFactory = new SunBotFactory();
    private readonly static SnowBotFactory SnowBotFactory = new SnowBotFactory();

    public static List<Bots> LoadFromJsonFile(string path)
    {
        string fileStream = File.ReadAllText(path);
        JsonSerializerOptions options = new JsonSerializerOptions
        {
            PropertyNamingPolicy = null
            
        };
        BotsConfig? config = JsonSerializer.Deserialize<BotsConfig>(fileStream,options);
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