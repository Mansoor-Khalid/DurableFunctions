using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


var host = new HostBuilder()
.ConfigureFunctionsWorkerDefaults()
////#if DEBUG
.ConfigureAppConfiguration(config =>
{
    config
        .AddJsonFile("appsettings.json", true, true)
        .AddJsonFile("local.settings.json", optional: true, reloadOnChange: true)
        .AddEnvironmentVariables()
        .Build();
})
////#endif
.ConfigureServices(services =>
{
    services.AddSingleton(sp => sp.GetRequiredService<ILoggerFactory>().CreateLogger("DefaultLogger"));
})
.Build();

host.Run();
