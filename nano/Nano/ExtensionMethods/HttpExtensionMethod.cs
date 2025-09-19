namespace Nano.ExtensionMethods;

public static class HttpExtensionMethod
{
    public static void ConfigureNanoHtpp(HostBuilderContext context, IServiceCollection services)
    {
#if DEBUG
        // DelegatingHandler will be automatically injected
        services.AddTransient<DelegatingHandler, DebugHttpHandler>();
#endif
    }
}
