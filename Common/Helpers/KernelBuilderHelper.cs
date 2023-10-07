using Microsoft.SemanticKernel;

namespace Common.Helpers;

public static class KernelBuilderHelper
{
    public static IKernel CreateKernel(
        string deploymentName,
        string endpoint,
        string apiKey)
    {
        var builder = new KernelBuilder();

        builder.WithAzureChatCompletionService(
            deploymentName,
            endpoint,
            apiKey);

        return builder.Build();
    }
}