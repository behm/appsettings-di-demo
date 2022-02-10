using AppSettingsDependencyInjectionDemo.Config;

namespace AppSettingsDependencyInjectionDemo;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly AppSettings _appSettings;

    public Worker(ILogger<Worker> logger, AppSettings appSettings)
    {
        _logger = logger;
        _appSettings = appSettings;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            _logger.LogInformation($"Settings: timeout={_appSettings.Timeout} apiKey={_appSettings.ApiKey}");
            await Task.Delay(1000, stoppingToken);
        }
    }
}
