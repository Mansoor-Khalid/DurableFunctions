using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


namespace DurableFunctions;

public static class Program
{
    public static void Main(string[] args)
    {
        var host = new HostBuilder()
        .ConfigureFunctionsWorkerDefaults()
        .ConfigureAppConfiguration(config =>
        {
            config
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();
        })
        .ConfigureServices(services =>
        {
            services.AddSingleton(sp => sp.GetRequiredService<ILoggerFactory>().CreateLogger("DefaultLogger"));
        })
        .Build();

        host.Run();
    }
}
