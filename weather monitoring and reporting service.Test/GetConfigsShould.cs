using System.Text.Json;
using AutoFixture;
using Moq;
using weather_monitoring_and_reporting_service.models.Bots;
using weather_monitoring_and_reporting_service.models.Bots.Conditions;
using weather_monitoring_and_reporting_service.models.Bots.Configs;
using weather_monitoring_and_reporting_service.models.Bots.Types;
using weather_monitoring_and_reporting_service.models.Weather;

namespace weather_monitoring_and_reporting_service.T;

public class GetConfigsShould
{
    private readonly Fixture _fixture;
    private readonly GetConfigs _getConfigs;

    public GetConfigsShould()
    {
        _fixture = new Fixture();
        _getConfigs = new GetConfigs();
        _fixture.Customize<ICheckConditionBehavior>(c =>
            c.FromFactory(() =>
            {
                var mock = new Mock<ICheckConditionBehavior>();
                mock.Setup(m => m.CheckForConditions(It.IsAny<Weather>())).Returns(true);
                return mock.Object;
            })
        );
    }

    [Fact]
    public void LoadFromJsonFile_FileNotFound_ThrowsFileNotFoundException()
    {
        // Arrange
        string path = "non_existent_file.json";

        // Act & Assert
        var exception = Assert.Throws<FileNotFoundException>(() => _getConfigs.LoadFromJsonFile(path));
        Assert.Contains("No config file found", exception.Message);
    }

    [Fact]
    public void LoadFromJsonFile_InvalidJson_ThrowsJsonException()
    {
        // Arrange
        string path = "invalid_config.json";
        File.WriteAllText(path, "Invalid JSON");

        // Act & Assert
        Assert.Throws<JsonException>(() => _getConfigs.LoadFromJsonFile(path));

        // Cleanup
        File.Delete(path);
    }

    [Theory]
    [InlineData(true, true, false, 2)]
    [InlineData(true, true, true, 3)]
    [InlineData(false, false, false, 0)]
    public void LoadFromJsonFile_ValidJson_Ok(bool rainBotEnabled, bool sunBotEnabled, bool snowBotEnabled,
        int botsCount)
    {
        //Arrange
        string path = Path.Combine(Directory.GetCurrentDirectory(), "../../../TestingFiles", "BotConfigTest.json");

        var rainBot = _fixture.Build<RainBot>().With(bot => bot.Enabled, rainBotEnabled).Create();
        var sunBot = _fixture.Build<SunBot>().With(bot => bot.Enabled, sunBotEnabled).Create();
        var snowBot = _fixture.Build<SnowBot>().With(bot => bot.Enabled, snowBotEnabled).Create();

        var expectedBotsConfig = new BotsConfig(
            rainBot,
            sunBot,
            snowBot
        );
        string jsonContent =
            JsonSerializer.Serialize(expectedBotsConfig, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, jsonContent);


        //Act
        List<Bot> bots = _getConfigs.LoadFromJsonFile(path);


        //Assert
        Assert.Equal(botsCount, bots.Count);
        var expectedBots = new List<Bot>();
        if (rainBotEnabled) expectedBots.Add(rainBot);
        if (sunBotEnabled) expectedBots.Add(sunBot);
        if (snowBotEnabled) expectedBots.Add(snowBot);

        Assert.Equal(expectedBots.Count, bots.Count);

        foreach (var expectedBot in expectedBots)
        {
            Assert.Contains(bots,
                bot => bot.Enabled == expectedBot.Enabled);
        }

        File.Delete(path);
    }
}