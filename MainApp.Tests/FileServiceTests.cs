using MainApp.Services;

namespace MainApp.Tests;

public class FileServiceTests
{
    [Fact]
    public void SaveAndRetrieveContent_ShouldWorkCorrectly()
    {
        // Arrange
        var fileService = new FileService("/tmp", "test_contacts.json");
        const string testData = "{\"FirstName\":\"Fredrik\", \"LastName\":\"Svensson\"}";

        // Act
        fileService.SaveContentToFile(testData);
        var retrievedData = fileService.GetContentFromFile();

        // Assert
        Assert.NotNull(retrievedData);
        Assert.Equal(testData, retrievedData);

        // Cleanup
        File.Delete("/tmp/test_contacts.json");
    }
}
