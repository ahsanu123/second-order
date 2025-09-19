using Uno.UI.Hosting;

namespace Nano;

internal class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
#if (!useDependencyInjection && useLoggingFallback)
        App.InitializeLogging();
#endif

        var host = UnoPlatformHostBuilder
            .Create()
            .App(() => new App())
            .UseX11()
            .UseLinuxFrameBuffer()
            .UseMacOS()
            .UseWin32()
            .Build();

        host.Run();
    }
}
