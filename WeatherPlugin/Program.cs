using Common.Configuration;
using Common.Helpers;
using Microsoft.SemanticKernel;
using WeatherPlugin.Plugins.Weather;

Console.WriteLine("Weather plugin");

// Get configuration
var weatherApiConfig = ConfigurationHelper.GetConfiguration<WeatherApiSettings>();

// Initialize kernel instance 
var kernel = new KernelBuilder().Build();

var weatherPlugin = kernel.ImportSkill(
    new SkWeatherPlugin(weatherApiConfig.ApiKey),
    nameof(SkWeatherPlugin));

Console.WriteLine("Please type the city for which you would like to check weather:");

var input = Console.ReadLine();

var result = await weatherPlugin["GetWeather"].InvokeAsync(input);

Console.WriteLine(result);
