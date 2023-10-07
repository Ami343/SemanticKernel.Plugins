namespace Common.Configuration;

public sealed class SpeechServiceSettings : IAppConfiguration
{
    public string SectionName { get; } = "speechService";

    public string ApiKey { get; set; }
    public string Region { get; set; }
}