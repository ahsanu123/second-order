namespace Nano.ExtensionMethods;

public static class LoggingExtensionMethod
{

    public static void ConfigureNanoLogging(HostBuilderContext context, ILoggingBuilder loggerBuilder)
    {
        // Configure log levels for different categories of logging
        loggerBuilder
            .SetMinimumLevel(
                context.HostingEnvironment.IsDevelopment()
                    ? LogLevel.Information
                    : LogLevel.Warning
            )
            // Default filters for core Uno Platform namespaces
            .CoreLogLevel(LogLevel.Warning);

        // Uno Platform namespace filter groups
        // Uncomment individual methods to see more detailed logging
        //// Generic Xaml events
        //logBuilder.XamlLogLevel(LogLevel.Debug);
        //// Layout specific messages
        //logBuilder.XamlLayoutLogLevel(LogLevel.Debug);
        //// Storage messages
        //logBuilder.StorageLogLevel(LogLevel.Debug);
        //// Binding related messages
        //logBuilder.XamlBindingLogLevel(LogLevel.Debug);
        //// Binder memory references tracking
        //logBuilder.BinderMemoryReferenceLogLevel(LogLevel.Debug);
        //// DevServer and HotReload related
        //logBuilder.HotReloadCoreLogLevel(LogLevel.Information);
        //// Debug JS interop
        //logBuilder.WebAssemblyLogLevel(LogLevel.Debug);
    }
}
