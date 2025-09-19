namespace Nano.ExtensionMethods;

public static class ConfigurationExtensionMethod
{
    public static IHostBuilder ConfigureNanonConfiguration(IConfigBuilder configBuilder)
    {
        configBuilder.EmbeddedSource<App>().Section<AppConfig>();

        return configBuilder;
    }
}
