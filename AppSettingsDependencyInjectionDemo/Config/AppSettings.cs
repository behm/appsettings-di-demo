namespace AppSettingsDependencyInjectionDemo.Config;

public class AppSettings
{
    public int Timeout { get; set; }
    public string ApiKey { get; set; }
}

public class MoreSettings
{
    public string UserName { get; set; }
    public Uri LoginUri { get; set; }
}