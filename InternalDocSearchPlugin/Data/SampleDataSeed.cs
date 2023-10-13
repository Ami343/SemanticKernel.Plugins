using Microsoft.SemanticKernel.Memory;

namespace InternalDocSearchPlugin.Data;

public static class SampleDataSeed
{
    public static async Task SeedMemory(ISemanticTextMemory memory)
    {
        var samples = SampleData();

        foreach (var entry in samples)
        {
            await memory.SaveReferenceAsync(
                collection: Constants.Constants.DataCollectionName,
                externalSourceName: "GitHub",
                externalId: entry.Key,
                description: entry.Value,
                text: entry.Value,
                cancellationToken: CancellationToken.None);
        }
    }

    private static Dictionary<string, string> SampleData()
        => new()
        {
            ["https://github.com/microsoft/semantic-kernel/blob/main/README.md"]
                = "README: Installation, getting started, and how to contribute",
            ["https://github.com/microsoft/semantic-kernel/blob/main/dotnet/notebooks/02-running-prompts-from-file.ipynb"]
                = "Jupyter notebook describing how to pass prompts from a file to a semantic plugin or function",
            ["https://github.com/microsoft/semantic-kernel/blob/main/dotnet/notebooks//00-getting-started.ipynb"]
                = "Jupyter notebook describing how to get started with the Semantic Kernel",
            ["https://github.com/microsoft/semantic-kernel/tree/main/samples/plugins/ChatPlugin/ChatGPT"]
                = "Sample demonstrating how to create a chat plugin interfacing with ChatGPT",
            ["https://github.com/microsoft/semantic-kernel/blob/main/dotnet/src/SemanticKernel/Memory/VolatileMemoryStore.cs"]
                = "C# class that defines a volatile embedding store",
            ["https://github.com/microsoft/semantic-kernel/blob/main/samples/dotnet/KernelHttpServer/README.md"]
                = "README: How to set up a Semantic Kernel Service API using Azure Function Runtime v4",
            ["https://github.com/microsoft/semantic-kernel/blob/main/samples/apps/chat-summary-webapp-react/README.md"]
                = "README: README associated with a sample chat summary react-based webapp",
        };
}