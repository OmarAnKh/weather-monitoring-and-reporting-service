namespace weather_monitoring_and_reporting_service.models.Weather;

public class JsonToPersonAdapter: IWeather
{
    public string Location { get; set; }
    public decimal Temperature { get; set; }
    public decimal Humidity { get; set; }
}