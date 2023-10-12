using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.SkillDefinition;
using WeatherPlugin.Plugins.Weather;

namespace WeatherPlugin.Extensions;

public static class KernelExtensions
{
    public static IDictionary<string, ISKFunction> ImportWeatherPlugin(this IKernel kernel, string apiKey)
        => kernel.ImportSkill(new SkWeatherPlugin(apiKey), nameof(SkWeatherPlugin));
}