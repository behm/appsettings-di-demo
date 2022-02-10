using AppSettingsDependencyInjectionDemo.Config;

namespace AppSettingsDependencyInjectionDemo;

public class Worker : BackgroundService
{
    private readonly ILogger<Worker> _logger;
    private readonly AppSettings _appSettings;
    private readonly MoreSettings _moreSettings;

    public Worker(ILogger<Worker> logger, AppSettings appSettings, MoreSettings moreSettings)
    {
        _logger = logger;
        _appSettings = appSettings;
        _moreSettings = moreSettings;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            _logger.LogInformation($"AppSettings: timeout={_appSettings.Timeout} apiKey={_appSettings.ApiKey}");
            _logger.LogInformation($"MoreSettings: username={_moreSettings.UserName} LoginUri={_moreSettings.LoginUri}");
            await Task.Delay(1000, stoppingToken);
        }
    }
}
