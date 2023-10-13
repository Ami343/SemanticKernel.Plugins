using ChainedFunctions.Skills;
using Microsoft.SemanticKernel;

namespace ChainedFunctions.Extensions;

public static class KernelExtensions
{
    public static IDictionary<string, ISKFunction> ImportExtractJsonPlugin(this IKernel kernel)
        => kernel.ImportFunctions(new ExtractJson(), nameof(ExtractJson));
}