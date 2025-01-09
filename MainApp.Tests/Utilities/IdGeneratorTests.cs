using MainApp.Utilities;
using Xunit;

namespace MainApp.Tests.Utilities;

public class IdGeneratorTests
{
    [Fact]
    /* Detta är genererat av Chat GPT 4o - Denna kod kontrollerar först att GUID inte är tomt */
    public void Generate_ShouldReturnValidGuid()
    {
        // Act
        var result = IdGenerator.Generate();

        // Assert
        Assert.NotEqual(Guid.Empty, result);
    }

    [Fact]
    /* Detta är genererat av Chat GPT 4o - Denna kod kontrollerar att två olika anrop ger olika GUID's */
    public void Generate_ShouldReturnUniqueGuids()
    {
        // Act
        var guid1 = IdGenerator.Generate();
        var guid2 = IdGenerator.Generate();

        // Assert
        Assert.NotEqual(guid1, guid2);
    }
}