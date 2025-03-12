using System.Text.Json;

namespace weather_monitoring_and_reporting_service.models.Bots.Configs
{
    public class GetConfigs : IGetConfigs
    {
        public List<Bot> LoadFromJsonFile(string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException($"No config file found at {path}");
            }

            try
            {
                string jsonContent = File.ReadAllText(path);

                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    PropertyNamingPolicy = null
                };

                BotsConfig? config = JsonSerializer.Deserialize<BotsConfig>(jsonContent, options);

                if (config is null)
                {
                    throw new JsonException("Failed to deserialize the config.");
                }

                var bots = new List<Bot>();
                if (config.RainBot.Enabled) bots.Add(config.RainBot);
                if (config.SunBot.Enabled) bots.Add(config.SunBot);
                if (config.SnowBot.Enabled) bots.Add(config.SnowBot);
                return bots;
            }
            catch (JsonException)
            {
                throw new JsonException("Failed to parse the JSON content.");
            }
        }
    }
}