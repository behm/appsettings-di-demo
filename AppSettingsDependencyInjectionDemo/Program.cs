using AppSettingsDependencyInjectionDemo;
using AppSettingsDependencyInjectionDemo.Config;

using Microsoft.Extensions.Options;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        var configuration = hostContext.Configuration;

        services.Configure<AppSettings>(configuration.GetSection("AppSettings"));
        services.AddSingleton(registeredServices =>
            registeredServices.GetRequiredService<IOptions<AppSettings>>().Value);

        services.Configure<MoreSettings>(configuration.GetSection("MoreSettings"));
        services.AddSingleton(registeredServices =>
            registeredServices.GetRequiredService<IOptions<MoreSettings>>().Value);

        services.AddHostedService<Worker>();
    })
    .Build();

await host.RunAsync();
