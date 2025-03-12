using weather_monitoring_and_reporting_service.models.Bots.Conditions;
using weather_monitoring_and_reporting_service.models.Weather;

namespace weather_monitoring_and_reporting_service.T;

public class CheckConditionShould
{
    [Theory]
    [InlineData(30, 20, false)]
    [InlineData(30, 40, true)]
    public void AboveTemperatureThreshold(decimal baseTemperature, decimal temperature, bool result)
    {
        //Arrange
        var condition = new AboveTemperatureThresholdCheckCondition(baseTemperature);
        var weather = new Weather { Temperature = temperature };

        //Act
        var conditionResult = condition.CheckForConditions(weather);

        //Assert
        Assert.Equal(result, conditionResult);
    }

    [Theory]
    [InlineData(0, -1, true)]
    [InlineData(0, 40, false)]
    public void BelowTemperatureThreshold(decimal baseTemperature, decimal temperature, bool result)
    {
        //Arrange
        var condition = new BelowTemperatureThresholdCheckCondition(baseTemperature);
        var weather = new Weather { Temperature = temperature };

        //Act
        var conditionResult = condition.CheckForConditions(weather);

        //Assert
        Assert.Equal(result, conditionResult);
    }

    [Theory]
    [InlineData(70, 20, false)]
    [InlineData(70, 85, true)]
    public void HumidityThreshold(decimal baseHumidity, decimal humidity, bool result)
    {
        //Arrange
        var condition = new HumidityThresholdCheckCondition(baseHumidity);
        var weather = new Weather { Humidity = humidity };

        //Act
        var conditionResult = condition.CheckForConditions(weather);

        //Assert
        Assert.Equal(result, conditionResult);
    }
}