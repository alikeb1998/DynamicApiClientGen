namespace DynamicApiClientGen.Core;

public class FileWriter
{
    public static void WriteToFile(string outputPath, string content)
    {
        File.WriteAllText(outputPath, content);
    }
}