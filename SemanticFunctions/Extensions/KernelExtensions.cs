using Microsoft.SemanticKernel;

namespace SemanticFunctions.Extensions;

public static class KernelExtensions
{
    public static IDictionary<string, ISKFunction> ImportHrAssistantSkill(this IKernel kernel)
    {
        var skillsDir = Path.Combine(Directory.GetCurrentDirectory(), "Skills");
        var skill = kernel.ImportSemanticFunctionsFromDirectory(skillsDir, "HRAssistantSkill");

        return skill;
    }
    
    public static IDictionary<string, ISKFunction> ImportCitySkill(this IKernel kernel)
    {
        var skillsDir = Path.Combine(Directory.GetCurrentDirectory(), "Skills");
        var skill = kernel.ImportSemanticFunctionsFromDirectory(skillsDir, "CitySkill");

        return skill;
    }
}