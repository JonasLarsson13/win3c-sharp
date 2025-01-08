namespace MainApp.Services;

public class FileService
{
    private readonly string _directoryPath;
    private readonly string _filePath;

    public FileService(string directoryPath = "Data", string fileName = "contacts.json")
    {
        // Filen hamnar MainApp/bin/Debug/net9.0/Data ->
        _directoryPath = Path.Combine(AppContext.BaseDirectory, directoryPath);
        _filePath = Path.Combine(_directoryPath, fileName);
    }

    public void SaveContentToFile(string content)
    {
        if (string.IsNullOrEmpty(content)) return;
        
        if (!Directory.Exists(_directoryPath))
            Directory.CreateDirectory(_directoryPath);

        File.WriteAllText(_filePath, content);
    }

    public string? GetContentFromFile()
    {
        return File.Exists(_filePath) ? File.ReadAllText(_filePath) : null;
    }
}
