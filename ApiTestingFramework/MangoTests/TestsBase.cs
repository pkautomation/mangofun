using MangoTests.Config;
using Microsoft.Extensions.Configuration;

[SetUpFixture]
public class TestsBase
{
    public readonly Settings? Settings;

    public TestsBase()
    {
        var config = new ConfigurationBuilder()
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddUserSecrets<TestsBase>(true, true)
        .Build();

        Settings = config.GetSection("Settings").Get<Settings>() ?? throw new InvalidOperationException("Settings section is missing or invalid in the configuration.");
    }
}