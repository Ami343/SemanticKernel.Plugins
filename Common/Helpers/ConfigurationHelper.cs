using Common.Configuration;
using Microsoft.Extensions.Configuration;

namespace Common.Helpers;

public static class ConfigurationHelper
{
    public static TConig GetConfiguration<TConig>() where TConig : IAppConfiguration
    {
        var appConfiguration = GetConfigurationBuilder();
        
        var config = Activator.CreateInstance<TConig>(); 
        appConfiguration.Bind(config.SectionName, config);

        return config;
    }

    private static IConfiguration GetConfigurationBuilder()
        => new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();
}