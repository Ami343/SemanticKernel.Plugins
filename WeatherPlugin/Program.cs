using Common.Configuration;
using Common.Helpers;
using Microsoft.SemanticKernel.Planning;
using WeatherPlugin.Plugins.Weather;

Console.WriteLine("Weather plugin");

// Get configuration
var weatherApiConfig = ConfigurationHelper.GetConfiguration<WeatherApiSettings>();
var azureOpenAiConfig = ConfigurationHelper.GetConfiguration<AzureOpenAiSettings>();

// Initialize kernel instance
var kernel = KernelBuilderHelper.CreateKernel(azureOpenAiConfig);

// Import plugin
kernel.ImportSkill(
    new SkWeatherPlugin(weatherApiConfig.ApiKey),
    nameof(SkWeatherPlugin));

// Create planner 
var planner = new SequentialPlanner(kernel);

Console.WriteLine("Please type to which city you would like to travel:");
var input = Console.ReadLine();

var plan =  await planner.CreatePlanAsync(input!);

var result = await plan.InvokeAsync(kernel.CreateNewContext());

Console.WriteLine(result);
