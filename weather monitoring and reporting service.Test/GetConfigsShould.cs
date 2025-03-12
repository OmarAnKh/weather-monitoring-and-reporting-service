using System.Text.Json;
using AutoFixture;
using Moq;
using weather_monitoring_and_reporting_service.models.Bots.Configs;

namespace weather_monitoring_and_reporting_service.T;

public class GetConfigsShould
{
    private readonly Fixture _fixture;
    private readonly Mock<IGetConfigs> _mockGetConfigs;
    private readonly GetConfigs _getConfigs;

    public GetConfigsShould()
    {
        _fixture = new Fixture();
        _mockGetConfigs = new Mock<IGetConfigs>();
        _getConfigs = new GetConfigs();
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
    
    
}