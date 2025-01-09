using MainApp.Utilities;

namespace MainApp.Tests.Utilities;

public class ValidatorTests
{
    [Theory]
    [InlineData("test@testar.nu", true)]
    [InlineData("not-valid", false)]
    [InlineData("user@domain.se", true)]
    [InlineData("missing@tld", false)]
    [InlineData("", false)]
    public void IsValidEmail_ShouldValidateEmail(string email, bool expected)
    {
        // act
        var result = Validator.IsValidEmail(email);
        
        // assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1234567890", true)]
    [InlineData("+46726663389", true)]
    [InlineData("070-2929076", true)]
    [InlineData("not-valid", false)]
    [InlineData("", false)]
    public void IsValidPhoneNumber_ShouldValidatePhoneNumber(string phone, bool expected)
    {
        // act
        var result = Validator.IsValidPhone(phone);
        
        // assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("12345", true)]
    [InlineData("54321", true)]
    [InlineData("1234", false)]
    [InlineData("123456", false)]
    [InlineData("12a45", false)]
    [InlineData("", false)]
    public void IsValidPostalCode_ShouldValidatePostalCode(string postalCode, bool expected)
    {
        // act
        var result = Validator.IsValidZipCode(postalCode);
        
        // assert
        Assert.Equal(expected, result);
    }
}