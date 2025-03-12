// See https://aka.ms/new-console-template for more information

using weather_monitoring_and_reporting_service.models;
using weather_monitoring_and_reporting_service.models.Bots.Configs;
using weather_monitoring_and_reporting_service.models.Weather.Parsers;


GetConfigs bots = new GetConfigs();
IWeatherParserFactory jsonFactory = new JsonParserFactory();
IWeatherParserFactory xmlFactory = new XmlParserFactory();
WeatherBots jsonProgram = new WeatherBots(bots, jsonFactory, "../../../files/BotsConfiguration.json");
WeatherBots xmlProgram = new WeatherBots(bots, xmlFactory, "../../../files/BotsConfiguration.json");

while (true)
{
    Console.WriteLine("Enter weather data (JSON or XML) or type 'exit' to quit:");
    string? input = Console.ReadLine()?.Trim();

    if (string.IsNullOrWhiteSpace(input))
    {
        Console.WriteLine("Invalid input. Please enter valid weather data.");
        continue;
    }

    if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine("Exiting program...");
        break;
    }

    if (input.StartsWith("{"))
    {
        jsonProgram.CheckWeatherBots(input);
    }
    else if (input.StartsWith("<"))
    {
        xmlProgram.CheckWeatherBots(input);
    }
    else
    {
        Console.WriteLine("Invalid format. Please enter weather data in JSON or XML format.");
    }
}