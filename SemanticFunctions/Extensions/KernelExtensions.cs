using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.SkillDefinition;

namespace SemanticFunctions.Extensions;

public static class KernelExtensions
{
    public static IDictionary<string, ISKFunction> ImportHRAssistantSkill(this IKernel kernel)
    {
        var skillsDir = Path.Combine(Directory.GetCurrentDirectory(), "Skills");
        var skill = kernel.ImportSemanticSkillFromDirectory(skillsDir, "HRAssistantSkill");

        return skill;
    }
    
    public static IDictionary<string, ISKFunction> ImportCitySkill(this IKernel kernel)
    {
        var skillsDir = Path.Combine(Directory.GetCurrentDirectory(), "Skills");
        var skill = kernel.ImportSemanticSkillFromDirectory(skillsDir, "CitySkill");

        return skill;
    }
}