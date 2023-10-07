namespace Common.Configuration;

public sealed class AzureOpenAiSettings : IAppConfiguration
{
    public string SectionName { get; } = "azureOpenAiService";

    public string ApiKey { get; set; }
    public string Endpoint { get; set; }
    public string DeploymentName { get; set; }
}