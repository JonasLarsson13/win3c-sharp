namespace MainApp.Utilities;

public static class Validator
{
    public static bool IsValidPhone(string phone)
    {
        return phone.All(char.IsDigit) || phone.StartsWith("+") || phone.Contains('-');
    }

    public static bool IsValidZipCode(string zipCode)
    {
        return zipCode.Length == 5 && zipCode.All(char.IsDigit);
    }

    public static bool IsValidEmail(string email)
    {
        /* Detta är genererat av Chat GPT 4o - Denna kod kollar om det är en valid epost */
        try
        {
            var addr = new System.Net.Mail.MailAddress(email);
            return addr.Address == email;
        }
        catch
        {
            return false;
        }
    }
}