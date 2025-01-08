using System.Diagnostics;
using System.Text.Json;
using MainApp.Models;

namespace MainApp.Services;

public class ContactService
{
    private readonly FileService _fileService;
    private List<Contact> _contactsList = [];
    
    public ContactService(FileService fileService)
    {
        _fileService = fileService;
    }

    public void CreateContact(Contact model)
    {
        model.Id = Guid.NewGuid();
        model.CreatedDate = DateTime.Now;
        _contactsList.Add(model);

        var json = JsonSerializer.Serialize(_contactsList);
        _fileService.SaveContentToFile(json);
    }

    public IEnumerable<Contact> GetAllContacts()
    {
        var json = _fileService.GetContentFromFile();
        if (string.IsNullOrEmpty(json)) return _contactsList;

        try
        {
            _contactsList = JsonSerializer.Deserialize<List<Contact>>(json) ?? [];
        }
        catch (Exception e)
        {
            Debug.WriteLine(e.Message);
            _contactsList = [];
        }

        return _contactsList;
    }
}