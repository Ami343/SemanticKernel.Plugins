namespace Common.Configuration;

public class AzureOpenAiSettings
{
    public static string SectionName = "AzureOpenAiService";

    public string ApiKey { get; set; }
    public string Endpoint { get; set; }
    public string DeploymentName { get; set; }
}