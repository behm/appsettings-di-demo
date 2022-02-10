# Registering IOptions From Configuration

This application demonstrates registering a class that wraps a section of the appSettings.json and registers it as an IOption id DI for injection into other parts of the app (in this case, Worker)

With the worker template, there is also built-in support for user secrets so if you run the following commands, you can set a secret value and see that it's written out to the logs.  Without setting this secret, the log should show the value that is configured in the appSettings.json but after setting a user secret value, it will show that value instead.

```
dotnet user-secrets set "AppSettings:ApiKey" "some-secret-api-key"
```

Running this command to clear the User Secrets will then go back to displaying, in the logs, the values that are configured in appSettings.json

```
dotnet user-secrets clear
```
