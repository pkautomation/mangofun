namespace ApiTestingFramework.Helpers;

public class FileHelpers
{
    public static string ReadDocumentToString(string documentName)
    {
        string wholeDocName = $"Assets/{documentName}";

        using StreamReader reader = new(wholeDocName);

        return reader.ReadToEnd();
    }
}
