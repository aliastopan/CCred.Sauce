using SampleTests.Samples;

namespace SampleTests;

public static class Sampling
{
    public static void Run()
    {
        Serilog.Log.Information("Starting...");
        // Gibberish.Run();
        ExtraSpicy.Run();
    }
}
