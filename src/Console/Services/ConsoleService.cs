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

        // var x = CCred.Sauce.GetHash<SHA384>("password", Encoding.UTF8);
        var salt = CCred.Sauce.GenerateSalt(8);
        var password = "VeryLongPassword";
        var x = CCred.Sauce.Seasoning(password, salt);
        var z = CCred.Sauce.GetHash(x);
        _logger.LogInformation($"Salt: {salt}");
        _logger.LogInformation($"Seasoning: {x}");
        _logger.LogInformation($"CCred: {z}");
    }
}