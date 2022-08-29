namespace SampleTests.Samples;

public static class Gibberish
{
    public static void Run()
    {
        for (int i = 0; i < 10; i++)
        {
            var token = CCred.Sauce.GenerateGibberish(32, "#$?._*-");
            Serilog.Log.Information("Token: {token}", token);
        }
    }
}
