using System.ComponentModel;
using Microsoft.SemanticKernel.Orchestration;
using Microsoft.SemanticKernel.SkillDefinition;
using Newtonsoft.Json.Linq;

namespace ChainedFunctions.Skills;

public class ExtractJson
{
    [SKFunction,Description("Extract information form JSON")]
    public SKContext? ExtractInfo(SKContext? context)
    {
        ArgumentNullException.ThrowIfNull(context);

        context.Variables.TryGetValue("input", out var inputValue);

        var jsonObj = JObject.Parse(inputValue ?? string.Empty);

        if (jsonObj.TryGetValue("cityname", out var cityName))
            context.Variables.Set("input", cityName.ToString());

        if (jsonObj.TryGetValue("history", out var cityHistory))
            context.Variables.Set("history", cityHistory.ToString());

        return context;
    }
}