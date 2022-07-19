using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace Console.Services;

public class ConsoleService : IConsoleService
{
    private readonly ILogger<ConsoleService> _logger;
    private readonly IConfiguration _config;

    public ConsoleService(ILogger<ConsoleService> logger, IConfiguration config)
    {
        _logger = logger;
        _config = config;
    }

    public void Run()
    {
        _logger.LogInformation("Starting...");

        var salt = CCred.Sauce.GenerateSalt(8);
        var password = "VeryLongPassword";
        var storedPassword = CCred.Sauce.Seasoning(password, salt);
        var salyPassword = CCred.Sauce.GetHash(storedPassword);

        _logger.LogInformation($"Salt: {salt}");
        _logger.LogInformation($"Seasoning: {storedPassword}");
        _logger.LogInformation($"CCred: {salyPassword}");

        var verify = CCred.Sauce.Verify<SHA512>(password, salt, salyPassword);
        _logger.LogInformation($"Verify: {verify}");
    }
}