namespace Common.Configuration;

public class WeatherApiSettings : IAppConfiguration
{
    public string SectionName { get; } = "weatherApi";

    public string ApiKey { get; set; }
}