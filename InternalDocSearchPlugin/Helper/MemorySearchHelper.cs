using Microsoft.SemanticKernel.Memory;

namespace InternalDocSearchPlugin.Helper;

public static class MemorySearchHelper
{
    public static async Task Search(ISemanticTextMemory memory, string query)
    {
        var results = memory.SearchAsync(
            Constants.Constants.DataCollectionName,
            query,
            limit: 2,
            minRelevanceScore: 0.5);    

        var i = 0;
        await foreach (var memoryResult in results)
        {
            Console.WriteLine($"Result {++i}:");
            Console.WriteLine("  URL:     : " + memoryResult.Metadata.Id);
            Console.WriteLine("  Title    : " + memoryResult.Metadata.Description);
            Console.WriteLine("  Relevance: " + memoryResult.Relevance);
            Console.WriteLine();
        }
    }

}
