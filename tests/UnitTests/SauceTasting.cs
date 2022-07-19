namespace UnitTests;

public class SauceTasting
{
    private string _password = "VeryLongPassword";
    private string _salt = CCred.Sauce.GenerateSalt(8);

    [Theory]
    [InlineData("verylongpassword")]
    [InlineData("VeryLongpassword")]
    [InlineData("veryLongPassword")]
    public void Should_ReturnFalse(string password)
    {
        var hashDefault = CCred.Sauce.GetHash(_password, _salt);

        Assert.False(CCred.Sauce.Verify(password, _salt, hashDefault));
    }

    [Theory]
    [InlineData("VeryLongPassword")]
    public void Should_ReturnTrue(string password)
    {
        var hashDefault = CCred.Sauce.GetHash(_password, _salt);

        Assert.True(CCred.Sauce.Verify(password, _salt, hashDefault));
    }
}