namespace weather_monitoring_and_reporting_service.models.Weather;

public abstract class Weather(string location, decimal temperature, decimal humidity)
{
    public string Location { get; set; } = location;
    public decimal Temperature { get; set; } = temperature;
    public decimal Humidity { get; set; } = humidity;
}