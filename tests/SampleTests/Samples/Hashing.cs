using System.Security.Cryptography;

namespace SampleTests.Samples;

public static class Hashing
{
    public static void Run()
    {
        Serilog.Log.Information("Starting...");

        var salt = CCred.Sauce.GenerateSalt(8);
        var password = "VeryLongPassword";
        var storedPassword = CCred.Sauce.Seasoning(password, salt);
        var saltyPassword = CCred.Sauce.GetHash(storedPassword);

        Serilog.Log.Information("Salt: {salt}", salt);
        Serilog.Log.Information("Seasoning: {storedPassword}", storedPassword);
        Serilog.Log.Information("CCred: {saltyPassword}", saltyPassword);

        var verify = CCred.Sauce.Verify<SHA512>(password, salt, saltyPassword);
        Serilog.Log.Information("Verify: {verify}", verify);

        for (int i = 0; i < 10; i++)
        {
            var token = CCred.Sauce.GenerateGibberish(32, "#$?._*-");
            Serilog.Log.Information("Token: {token}", token);
        }
    }
}
