using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace Console.Services;

public class ConsoleService : IConsoleService
{
    private readonly ILogger<ConsoleService> _logger;

    public ConsoleService(ILogger<ConsoleService> logger)
    {
        _logger = logger;
    }

    public void Run()
    {
        _logger.LogInformation("Starting...");

        var salt = CCred.Sauce.GenerateSalt(8);
        var password = "VeryLongPassword";
        var storedPassword = CCred.Sauce.Seasoning(password, salt);
        var saltyPassword = CCred.Sauce.GetHash(storedPassword);

        _logger.LogInformation("Salt: {salt}", salt);
        _logger.LogInformation("Seasoning: {storedPassword}", storedPassword);
        _logger.LogInformation("CCred: {saltyPassword}", saltyPassword);

        var verify = CCred.Sauce.Verify<SHA512>(password, salt, saltyPassword);
        _logger.LogInformation("Verify: {verify}", verify);

        for (int i = 0; i < 10; i++)
        {
            var token = CCred.Sauce.GenerateGibberish(32, "#$?._*-");
            _logger.LogInformation("Token: {token}", token);
        }
    }
}