using System.Text.RegularExpressions;

namespace MainApp.Utilities;

public static class Validator
{
    public static bool IsValidPhone(string phone)
    {
        if (string.IsNullOrWhiteSpace(phone))
            return false;

        var phoneRegex = new Regex(@"^\+?[0-9]+(-[0-9]+)*$");
        return phoneRegex.IsMatch(phone);
    }

    public static bool IsValidZipCode(string zipCode)
    {
        return zipCode.Length == 5 && zipCode.All(char.IsDigit);
    }

    public static bool IsValidEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            return false;
        
        var emailRegex = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$");
        return emailRegex.IsMatch(email);
    }
}