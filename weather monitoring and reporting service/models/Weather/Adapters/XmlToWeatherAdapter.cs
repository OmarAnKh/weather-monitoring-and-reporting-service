using System.Xml;
using weather_monitoring_and_reporting_service.models.Weather.Parsers;

namespace weather_monitoring_and_reporting_service.models.Weather.Adapters
{
    public class XmlToWeatherAdapter : IParser
    {
        public Weather? Parse(string? weather)
        {
            if (weather == null)
                return null;
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(weather);
                Weather weatherData = new Weather
                {
                    Location = xmlDoc.SelectSingleNode("//WeatherData/Location")?.InnerText ?? "Unknown",
                    Temperature = decimal.Parse(xmlDoc.SelectSingleNode("//WeatherData/Temperature")?.InnerText ?? "0"),
                    Humidity = decimal.Parse(xmlDoc.SelectSingleNode("//WeatherData/Humidity")?.InnerText ?? "0")
                };
                return weatherData;
            }
            catch (XmlException ex)
            {
                Console.WriteLine($"XML Parsing Error: {ex.Message}");
                return null;
            }
        }
    }
}