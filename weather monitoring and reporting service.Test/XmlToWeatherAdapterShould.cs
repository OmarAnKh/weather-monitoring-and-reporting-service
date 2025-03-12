using weather_monitoring_and_reporting_service.models.Weather;
using weather_monitoring_and_reporting_service.models.Weather.Adapters;

namespace weather_monitoring_and_reporting_service.T;

public class XmlToWeatherAdapterShould
{
    private readonly XmlToWeatherAdapter _xmlToWeatherAdapter = new();

    [Fact]
    public void ParseValidXmlReturnsWeatherObject()
    {
        //Arrange
        string xmlInput = @"<WeatherData>
                                <Location>Gaza</Location>
                                <Temperature>25.5</Temperature>
                                <Humidity>60</Humidity>
                            </WeatherData>";

        //Act
        Weather? result = _xmlToWeatherAdapter.Parse(xmlInput);


        //Assert
        Assert.NotNull(result);
        Assert.Equal("Gaza", result.Location);
        Assert.Equal(25.5m, result.Temperature);
        Assert.Equal(60m, result.Humidity);
    }

    [Fact]
    public void ParseInvalidXmlReturnsNull()
    {
        //Arrange
        string xmlInput = @"<WeatherData>
                                <Location>Gaza</Location>";

        //Act
        Weather? result = _xmlToWeatherAdapter.Parse(xmlInput);


        //Assert
        Assert.Null(result);
    }

    [Fact]
    public void ParseNullInputReturnsNull()
    {
        //Arrange

        //Act
        Weather? result = _xmlToWeatherAdapter.Parse(null);


        //Assert
        Assert.Null(result);
    }

    [Fact]
    public void Parse_MissingFields_UsesDefaults()
    {
        // Arrange
        string xmlInput = @"<WeatherData></WeatherData>";

        // Act
        Weather? result = _xmlToWeatherAdapter.Parse(xmlInput);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("Unknown", result.Location);
        Assert.Equal(0m, result.Temperature);
        Assert.Equal(0m, result.Humidity);
    }
}