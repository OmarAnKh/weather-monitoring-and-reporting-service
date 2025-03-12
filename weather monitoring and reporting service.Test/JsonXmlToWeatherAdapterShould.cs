using weather_monitoring_and_reporting_service.models.Weather;
using weather_monitoring_and_reporting_service.models.Weather.Adapters;

namespace weather_monitoring_and_reporting_service.T;

public class JsonXmlToWeatherAdapterShould
{
    private readonly JsonToWeatherAdapter _jsonToWeatherAdapter = new();

    [Fact]
    public void ParserValidJson()
    {
        // Arrange
        string jsonInput = @"{
                                ""Location"": ""Gaza"",
                                ""Temperature"": 25.5,
                                ""Humidity"": 60
                            }";

        //Act
        Weather? result = _jsonToWeatherAdapter.Parse(jsonInput);

        //Assert 
        Assert.NotNull(result);
        Assert.Equal("Gaza", result.Location);
        Assert.Equal(25.5m, result.Temperature);
        Assert.Equal(60m, result.Humidity);
    }

    [Fact]
    public void ParserInvalidJson()
    {
        // Arrange
        string invalidJson = "{ Location: Gaza, Temperature: 25.5 ";

        // Act
        Weather? result = _jsonToWeatherAdapter.Parse(invalidJson);

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public void ParserNullJson()
    {
        //Act
        Weather? result = _jsonToWeatherAdapter.Parse(null);

        //Assert
        Assert.Null(result);
    }

    [Fact]
    public void ParserEmptyJson()
    {
        //Arrange
        string jsonInput = "{}";

        //Act
        Weather? result = _jsonToWeatherAdapter.Parse(jsonInput);

        //Assert
        Assert.NotNull(result);
        Assert.Null(result.Location);
        Assert.Null(result.Temperature);
        Assert.Null(result.Humidity);
    }
}