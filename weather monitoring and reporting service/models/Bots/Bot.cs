using System.Text.Json.Serialization;
using weather_monitoring_and_reporting_service.models.Bots.Conditions;

namespace weather_monitoring_and_reporting_service.models.Bots
{
    public abstract class Bot(bool enabled, string? message, ICheckConditionBehavior checkCondition)
    {
        [JsonPropertyName("Enabled")] public bool Enabled { get; set; } = enabled;

        [JsonPropertyName("Message")] public string? Message { get; set; } = message;

        [JsonIgnore] public ICheckConditionBehavior CheckCondition { get; set; } = checkCondition;

        public bool Check(Weather.Weather? weather)
        {
            if (CheckCondition.CheckForConditions(weather))
            {
                Console.WriteLine($"{this.GetType().Name} activated!");
                Console.WriteLine($"{this.GetType().Name}: {Message}\n");
                return true;
            }

            return false;
        }
    }
}