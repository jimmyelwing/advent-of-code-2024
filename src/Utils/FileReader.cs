namespace advent_of_code_2024.Utils;

public static class FileReader
{
    public static List<string> ReadFileForDay(int day, bool exampleData = false)
    {
        var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        
        var dataFolder = Path.Combine(currentDirectory, @$"..\..\..\src\Days\Day{day}\Data\");
        var dataFolderPath = Path.GetFullPath(dataFolder);
        
        var extension = exampleData ? "example" : "data";
        
        var filePath = Path.Combine(dataFolderPath, $"Day{day}.{extension}");
        var fileExists = File.Exists(filePath);
        if (!fileExists)
            throw new FileNotFoundException($"Day{day}.data not found");
        
        var lines = File.ReadAllLines(filePath);
        return [.. lines];
    }
}