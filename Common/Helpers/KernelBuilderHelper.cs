using Common.Configuration;
using Microsoft.SemanticKernel;

namespace Common.Helpers;

public static class KernelBuilderHelper
{
    public static IKernel CreateKernel(AzureOpenAiSettings settings)
    {
        var builder = new KernelBuilder();

        builder.WithAzureChatCompletionService(
            settings.DeploymentName,
            settings.Endpoint,
            settings.ApiKey);

        return builder.Build();
    }
}