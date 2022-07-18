using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

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
    }
}