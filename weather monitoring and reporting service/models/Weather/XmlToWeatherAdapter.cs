using System.Xml;

namespace weather_monitoring_and_reporting_service.models.Weather
{
    public class XmlToWeatherAdapter:IParser
    {
        public Weather Parse(string? weather)
        { 
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                if (weather != null)
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
                throw;
            }
        }
    }
}