using Moq;
using weather_monitoring_and_reporting_service.models.Bots;
using weather_monitoring_and_reporting_service.models.Bots.Conditions;
using weather_monitoring_and_reporting_service.models.Bots.Types;
using weather_monitoring_and_reporting_service.models.Weather;

namespace weather_monitoring_and_reporting_service.T;

public class BotsShould
{
    [Theory]
    [InlineData(true, 50)]
    [InlineData(false, 20)]
    public void CheckRainBot(bool condition, decimal humidity)
    {
        //Arrange
        Bot bot = new RainBot(true, 30, "RainBot");

        //Act
        var result = bot.Check(new Weather { Humidity = humidity });

        //Assert
        Assert.Equal(condition, result);
    }

    [Theory]
    [InlineData(true, 50)]
    [InlineData(false, 20)]
    public void CheckSunBot(bool condition, decimal temperature)
    {
        //Arrange
        Bot bot = new SunBot(true, 30, "RainBot");

        //Act
        var result = bot.Check(new Weather { Temperature = temperature });

        //Assert
        Assert.Equal(condition, result);
    }

    [Theory]
    [InlineData(false, 50)]
    [InlineData(true, 20)]
    public void CheckSnowBot(bool condition, decimal temperature)
    {
        //Arrange
        Bot bot = new SnowBot(true, 30, "RainBot");

        //Act
        var result = bot.Check(new Weather { Temperature = temperature });

        //Assert
        Assert.Equal(condition, result);
    }
}