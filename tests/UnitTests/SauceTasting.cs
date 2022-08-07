using System.Security.Cryptography;
using System.Text;

namespace UnitTests;

public class SauceTasting
{
    private readonly string _password = "VeryLongPassword";
    private readonly string _salt = CCred.Sauce.GenerateSalt(8);

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
        Assert.True(CCred.Sauce.Verify<SHA384>(password, _salt, hashDefault));
    }

    [Theory]
    [InlineData("VeryLongPassword")]
    public void SHA258_Tests(string password)
    {
        var hash256 = CCred.Sauce.GetHash<SHA256>(_password, _salt);
        var hash384 = CCred.Sauce.GetHash<SHA384>(_password, _salt);
        var hash512 = CCred.Sauce.GetHash<SHA512>(_password, _salt);

        Assert.True(CCred.Sauce.Verify<SHA256>(password, _salt, hash256));
        Assert.False(CCred.Sauce.Verify<SHA256>(password, _salt, hash384));
        Assert.False(CCred.Sauce.Verify<SHA256>(password, _salt, hash512));
    }

    [Theory]
    [InlineData("VeryLongPassword")]
    public void SHA384_Tests(string password)
    {
        var hash256 = CCred.Sauce.GetHash<SHA256>(_password, _salt);
        var hash384 = CCred.Sauce.GetHash<SHA384>(_password, _salt);
        var hash512 = CCred.Sauce.GetHash<SHA512>(_password, _salt);

        Assert.False(CCred.Sauce.Verify<SHA384>(password, _salt, hash256));
        Assert.True(CCred.Sauce.Verify<SHA384>(password, _salt, hash384));
        Assert.False(CCred.Sauce.Verify<SHA384>(password, _salt, hash512));
    }

    [Theory]
    [InlineData("VeryLongPassword")]
    public void SHA512_Tests(string password)
    {
        var hash256 = CCred.Sauce.GetHash<SHA256>(_password, _salt);
        var hash384 = CCred.Sauce.GetHash<SHA384>(_password, _salt);
        var hash512 = CCred.Sauce.GetHash<SHA512>(_password, _salt);

        Assert.False(CCred.Sauce.Verify<SHA512>(password, _salt, hash256));
        Assert.False(CCred.Sauce.Verify<SHA512>(password, _salt, hash384));
        Assert.True(CCred.Sauce.Verify<SHA512>(password, _salt, hash512));
    }

    [Theory]
    [InlineData("VeryLongPassword")]
    public void EncodingTest(string password)
    {
        var hash384 = CCred.Sauce.GetHash(_password, _salt, Encoding.UTF32);
        Assert.False(CCred.Sauce.Verify(password, _salt, hash384));
    }
}