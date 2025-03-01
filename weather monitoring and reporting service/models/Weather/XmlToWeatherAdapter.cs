using System.Xml;

namespace weather_monitoring_and_reporting_service.models.Weather
{
    public class XmlToWeatherAdapter :IWeather
    {

        public XmlToWeatherAdapter(string xml)
        {

            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xml);

                Location = xmlDoc.SelectSingleNode("//WeatherData/Location")?.InnerText ?? "Unknown";
                Temperature = decimal.Parse(xmlDoc.SelectSingleNode("//WeatherData/Temperature")?.InnerText ?? "0");
                Humidity = decimal.Parse(xmlDoc.SelectSingleNode("//WeatherData/Humidity")?.InnerText ?? "0");
            }
            catch (XmlException ex)
            {
                Console.WriteLine($"XML Parsing Error: {ex.Message}");
                throw;
            }
        }

        public string? Location { get; set; }

        public decimal? Temperature { get; set; }

        public decimal? Humidity { get; set; }
    }
}