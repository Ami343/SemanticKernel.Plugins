using Microsoft.SemanticKernel;
using WeatherPlugin.Plugins.Weather;

namespace WeatherPlugin.Extensions;

public static class KernelExtensions
{
    public static void ImportWeatherPlugin(this IKernel kernel, string apiKey)
    {
        kernel.ImportSkill(new SkWeatherPlugin(apiKey), nameof(SkWeatherPlugin));
    }
}