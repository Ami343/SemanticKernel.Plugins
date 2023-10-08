using System.ComponentModel;
using Microsoft.SemanticKernel.Orchestration;
using Microsoft.SemanticKernel.SkillDefinition;

namespace WeatherPlugin.Plugins.Weather;

public class SkWeatherPlugin
{
    private readonly string _apiKey;
    private readonly HttpClient _httpClient;

    public SkWeatherPlugin(string apiKey)
    {
        _apiKey = apiKey;
        _httpClient = new HttpClient();
    }

    [SKFunction, Description("Get weather information based on the location")]
    [SKParameter("input","location or cityName")]
    public async Task<string?> GetWeather(SKContext context)
    {
        var input = context.Variables["input"];
        var url = BuildUrl(input);

        var result = await GetWeather(url);

        return result;
    }

    private string BuildUrl(string cityName)
        => $"http://api.weatherapi.com/v1/current.json?key={_apiKey}&q={cityName}&aqi=no";

    private async Task<string?> GetWeather(string url)
    {
        try
        {
            var response = await _httpClient.GetAsync(url);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Error while calling weather api: {e}");
            return null;
        }
    }
}