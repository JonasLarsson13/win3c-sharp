namespace MainApp.Utilities;

public static class IdGenerator
{
    public static Guid Generate() => Guid.NewGuid();
}