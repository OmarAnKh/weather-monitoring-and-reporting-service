// See https://aka.ms/new-console-template for more information

using weather_monitoring_and_reporting_service.models.Bots;

GetConfigs bots = new GetConfigs();
var list = GetConfigs.LoadFromJsonFile("../../../files/BotsConfiguration.json");
Console.Read();