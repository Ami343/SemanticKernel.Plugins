using ChainedFunctions.Extensions;
using Common.Configuration;
using Common.Helpers;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel.Orchestration;
using SemanticFunctions.Extensions;
using WeatherPlugin.Extensions;

Console.WriteLine("Chained functions demo!");

using ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
{
    builder
        .SetMinimumLevel(LogLevel.Information)
        .AddConsole()
        .AddDebug();
});

var azureOpenAiConfig = ConfigurationHelper.GetConfiguration<AzureOpenAiSettings>();
var weatherApiConfig = ConfigurationHelper.GetConfiguration<WeatherApiSettings>();

var kernel = KernelBuilderHelper.CreateKernel(azureOpenAiConfig);

var citySkill = kernel.ImportCitySkill();
var weatherSkill = kernel.ImportWeatherPlugin(weatherApiConfig.ApiKey);
var extractJsonInfoSkill = kernel.ImportExtractJsonPlugin();

var context = new ContextVariables();

context.Set("input", "I'm planning to visit Catania in the end of current month.");

var result = await kernel.RunAsync(
    context,
    citySkill["History"], extractJsonInfoSkill["ExtractInfo"], weatherSkill["GetWeather"]);
    
Console.WriteLine(result);