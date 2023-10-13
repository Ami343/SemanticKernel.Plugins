using Microsoft.SemanticKernel;
using WeatherPlugin.Plugins.Weather;

namespace WeatherPlugin.Extensions;

public static class KernelExtensions
{
    public static IDictionary<string, ISKFunction> ImportWeatherPlugin(this IKernel kernel, string apiKey)
        => kernel.ImportFunctions(new SkWeatherPlugin(apiKey), nameof(SkWeatherPlugin));
}