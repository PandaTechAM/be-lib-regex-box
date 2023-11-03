using RegexBox;

namespace RegexBoxTests;

public class RegexTests
{
    [Theory]
    [InlineData("example@example.com", true)]
    [InlineData("firstname.lastname@example.com", true)]
    [InlineData("email@subdomain.example.com", true)]
    [InlineData("firstname+lastname@example.com", false)]
    [InlineData("1234567890@example.com", true)]
    [InlineData("email@123.123.123.123", true)]
    [InlineData("email@[123.123.123.123]", false)]
    [InlineData("plainaddress@example.com", true)]
    [InlineData("email@localhost", false)]
    [InlineData("firstname-lastname@example.com", true)]
    [InlineData("plainaddress", false)]
    [InlineData("@missingusername.com", false)]
    [InlineData("username@.com", false)]
    [InlineData("username@.com.com", false)]
    [InlineData("username@server..com", false)]
    [InlineData(".username@example.com", false)]
    [InlineData("username@example.com.", false)]
    [InlineData("username@.example.com", false)]
    [InlineData("username@.example..com", false)]
    [InlineData("username@example..com", false)]
    [InlineData("username@server..domain.com", false)]
    [InlineData("username@example.c", false)]
    [InlineData("username@example#.com", false)]
    [InlineData("username@server#domain.com", false)]
    [InlineData("username@server,domain.com", false)]
    [InlineData("username@example@com.com", false)]
    public void IsEmailTests(string email, bool expected)
    {
        var isValid = PandaValidator.IsEmail(email);
        Assert.Equal(expected, isValid);
    }

    [Theory]
    [InlineData("username", true)]
    [InlineData("username@", false)]
    [InlineData("12345", true)]
    [InlineData("user", false)]
    public void IsUsernameTests(string username, bool expected)
    {
        var isValid = PandaValidator.IsUsername(username);
        Assert.Equal(expected, isValid);
    }

    [Theory]
    [InlineData("123-45-6789", false)]
    [InlineData("987-65-4321", false)]
    [InlineData("555-55-5555", false)]
    [InlineData("111-11-1111", false)]
    [InlineData("123-45-678", false)] // Missing a digit
    [InlineData("9876-65-4321", false)] // Extra digit before first hyphen
    [InlineData("555-555-5555", false)] // Extra digit between hyphens
    [InlineData("00-00-00002", false)] // Extra digit at the end
    [InlineData("1111-11-1111", false)] // Extra digit at the start
    [InlineData("123-45-6789a", false)] // Letter at the end
    [InlineData("a23-45-6789", false)] // Letter at the start
    [InlineData("123-45-67890", false)] // Extra digit at the end
    [InlineData("123456789", false)] // No hyphens
    [InlineData("xyz-ab-cdef", false)] // Not even close to SSN format
    public void IsUsSocialSecurityNumberTests(string number, bool expected)
    {
        var isValid = PandaValidator.IsUsSocialSecurityNumber(number);
        Assert.Equal(expected, isValid);
    }

    // [Theory]
    // [InlineData("4111111111111111", true)] // Visa
    // [InlineData("5555555555554444", true)] // MasterCard
    // [InlineData("378282246310005", true)] // American Express
    // [InlineData("6011111111111117", true)] // Discover
    // [InlineData("3530111333300000", true)] // JCB
    // [InlineData("411111111111111", false)] // Shortened Visa number
    // [InlineData("55555555555544444", false)] // Extended MasterCard number
    // [InlineData("37828224631005", false)] // Shortened American Express
    // [InlineData("601111111111111", false)] // Shortened Discover number
    // [InlineData("353011133330000", false)] // Shortened JCB number
    // [InlineData("1234567890123456", false)] // Doesn't follow Luhn algorithm
    // [InlineData("abcdefabcdefabc", false)] // Contains non-numeric characters
    // [InlineData("4111-1111-1111-1111", false)] // Contains hyphens
    // [InlineData("4111 1111 1111 1111", false)] // Contains spaces
    // public void IsCreditCardNumberTests(string number, bool expected)
    // {
    //     var isValid = PandaValidator.IsCreditCardNumber(number);
    //     Assert.Equal(expected, isValid);
    // }

    [Theory]
    [InlineData("http://google.com", true)]
    [InlineData("https://google.com", true)]
    [InlineData("https://google.org", true)]
    [InlineData("https://openai.com", true)]
    [InlineData("http://example.travel", true)]
    [InlineData("https://example.co.uk", true)]
    [InlineData("google.com", false)]
    [InlineData("https://", false)]
    [InlineData("https://example.invalidTLD", false)]
    [InlineData("http://*.google.com", false)]
    [InlineData("http://sub.google.com", true)]
    [InlineData("https://*.openai.com", false)]
    [InlineData("*.google.com", false)]
    public void IsUrlTest(string value, bool expectedResult)
    {
        Assert.Equal(expectedResult, PandaValidator.IsUri(value, false, true));
    }

    [Theory]
    [InlineData("http://google.com", true)]
    [InlineData("https://google.com", true)]
    [InlineData("https://google.org", true)]
    [InlineData("https://openai.com", true)]
    [InlineData("http://example.travel", true)]
    [InlineData("https://example.co.uk", true)]
    [InlineData("google.com", false)]
    [InlineData("https://", false)]
    [InlineData("http://*.google.com", true)]
    [InlineData("http://sub.google.com", true)]
    [InlineData("https://*.openai.com", true)]
    [InlineData("*.google.com", false)]
    public void IsUrlOrWildcardTest(string value, bool expectedResult)
    {
        Assert.Equal(expectedResult, PandaValidator.IsUri(value, true, true));
    }

    [Theory]
    [InlineData("https://google.com", true)]
    [InlineData("https://google.org", true)]
    [InlineData("https://openai.com", true)]
    [InlineData("http://example.travel", false)]
    [InlineData("https://example.co.uk", true)]
    [InlineData("google.com", false)]
    [InlineData("https://", false)]
    [InlineData("http://*.google.com", false)]
    [InlineData("http://sub.google.com", false)]
    [InlineData("https://*.openai.com", false)]
    [InlineData("*.google.com", false)]
    [InlineData("http://google.com", false)]
    [InlineData("ftp://google.com", false)]
    public void IsSecureUrlTest(string value, bool expectedResult)
    {
        Assert.Equal(expectedResult, PandaValidator.IsUri(value, false, false));
    }

    [Theory]
    [InlineData("https://google.com", true)]
    [InlineData("https://google.org", true)]
    [InlineData("https://openai.com", true)]
    [InlineData("http://example.travel", false)]
    [InlineData("https://example.co.uk", true)]
    [InlineData("google.com", false)]
    [InlineData("https://", false)]
    [InlineData("http://*.google.com", false)]
    [InlineData("http://sub.google.com", false)]
    [InlineData("https://*.openai.com", true)]
    [InlineData("*.google.com", false)]
    [InlineData("http://google.com", false)]
    [InlineData("ftp://google.com", false)]
    [InlineData("https://*.google.com", true)]
    public void IsSecureUrlOrSecureWildcardTest(string value, bool expectedResult)
    {
        Assert.Equal(expectedResult, PandaValidator.IsUri(value, true, false));
    }

    [Theory]
    [InlineData("192.168.1.1", true)]
    [InlineData("255.255.255.255", true)]
    [InlineData("0.0.0.0", true)]
    [InlineData("256.256.256.256", false)]
    [InlineData("192.168.1", false)]
    public void IsIpv4Test(string value, bool expectedResult)
    {
        Assert.Equal(expectedResult, PandaValidator.IsIpAddress(value, true));
    }

    [Theory]
    [InlineData("2001:0db8:85a3:0000:0000:8a2e:0370:7334", true)]
    [InlineData("2001:db8:85a3:0:0:8a2e:370:7334", true)]
    [InlineData("2001:db8:85a3::8a2e:370:7334", true)]
    [InlineData("::1", true)]
    [InlineData("2001:db8::", true)]
    [InlineData("2001:db8:::1", true)]
    [InlineData("2001:0db8:85a3:0000:0000:8a2e:0370:7334:5", true)]
    public void IsIpv6Test(string value, bool expectedResult)
    {
        Assert.Equal(expectedResult, PandaValidator.IsIpAddress(value, false));
    }
}