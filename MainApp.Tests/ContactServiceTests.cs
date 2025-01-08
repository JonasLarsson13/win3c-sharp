using MainApp.Models;
using MainApp.Services;

namespace MainApp.Tests;

public class ContactServiceTests
{
    [Fact]
    public void CreateContact_ShouldAddContactToList()
    {
        // Arrange
        var fileService = new FileService("/tmp", "test_contacts.json");
        var contactService = new ContactService(fileService);
        var contact = new Contact
        {
            FirstName = "Fredrik",
            LastName = "Svensson",
            Email = "svensson@testet.nu",
            Phone = "0703030040",
            Address = "Västra gågatan 23A",
            ZipCode = "70340",
            City = "Örebro"
        };

        // Act
        contactService.CreateContact(contact);
        var contacts = contactService.GetAllContacts();

        // Assert
        var collection = contacts.ToList();
        Assert.NotEmpty(collection);
        Assert.Equal("Fredrik", collection.First().FirstName);

        // Cleanup
        File.Delete("/tmp/test_contacts.json");
    }
}