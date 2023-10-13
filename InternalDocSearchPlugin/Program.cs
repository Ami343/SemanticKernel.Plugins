using Common.Configuration;
using Common.Helpers;
using InternalDocSearchPlugin.Data;
using InternalDocSearchPlugin.Helper;
using Microsoft.SemanticKernel.Connectors.AI.OpenAI.TextEmbedding;
using Microsoft.SemanticKernel.Connectors.Memory.AzureCognitiveSearch;
using Microsoft.SemanticKernel.Plugins.Memory;

var azureOpenAiConfig = ConfigurationHelper.GetConfiguration<AzureOpenAiSettings>();
var acsConfig = ConfigurationHelper.GetConfiguration<AzureCognitiveSearchSettings>();

var memory = new MemoryBuilder()
    .WithLoggerFactory(LoggerHelper.CreateConsoleLogger())
    .WithTextEmbeddingGeneration(new AzureTextEmbeddingGeneration(azureOpenAiConfig.DeploymentName,
        azureOpenAiConfig.Endpoint, azureOpenAiConfig.ApiKey))
    .WithMemoryStore(new AzureCognitiveSearchMemoryStore(acsConfig.Endpoint, acsConfig.ApiKey))
    .Build();

const string prompt = "How do I get started?";

await SampleDataSeed.SeedMemory(memory);
await MemorySearchHelper.Search(memory, prompt);



