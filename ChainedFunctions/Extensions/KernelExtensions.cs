using ChainedFunctions.Skills;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.SkillDefinition;

namespace ChainedFunctions.Extensions;

public static class KernelExtensions
{
    public static IDictionary<string, ISKFunction> ImportExtractJsonPlugin(this IKernel kernel)
        => kernel.ImportSkill(new ExtractJson(), nameof(ExtractJson));
}