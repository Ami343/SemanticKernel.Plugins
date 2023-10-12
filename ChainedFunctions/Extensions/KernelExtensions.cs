using ChainedFunctions.Skills;
using Microsoft.SemanticKernel;

namespace ChainedFunctions.Extensions;

public static class KernelExtensions
{
    public static void ImportExtractJsonPlugin(this IKernel kernel)
    {
        kernel.ImportSkill(new ExtractJson(), nameof(ExtractJson));
    }
}