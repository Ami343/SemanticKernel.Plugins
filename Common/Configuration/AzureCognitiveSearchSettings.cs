namespace Common.Configuration;

public class AzureCognitiveSearchSettings : IAppConfiguration
{
    public string SectionName { get; } = "azureCognitiveSearch";

    public string ApiKey { get; set; }

    public string Endpoint { get; set; }
}