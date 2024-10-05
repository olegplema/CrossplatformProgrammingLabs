namespace App;

public static class FileProcessor
{
    private const string InputFileName = "INPUT.TXT";
    private const string OutputFileName = "OUTPUT.TXT";

    public static (int frets, string[] tuning, string chord) ParseInputFile()
    {
        if (!File.Exists(InputFileName))
        {
            throw new FileException($"Файл {InputFileName} не знайдено");
        }
        
        var lines = File.ReadAllLines(InputFileName)
            .Select(static line => line.Trim())
            .Where(static line => !string.IsNullOrWhiteSpace(line))
            .ToArray();

        if (lines.Length != 3)
        {
            throw new FileException("Файл має містити рівно 3 рядки");
        }
        
        var fretsArray = lines[0]
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (fretsArray.Length > 1)
        {
            throw new FileException("Перший рядок має містити лише одне число");
        }

        if (!int.TryParse(fretsArray[0], out var frets))
        {
            throw new FileException("Перший рядок має містити ціле число");
        }

        if (frets < 0 || frets > 9)
        {
            throw new FileException("Перший рядок має містити число від 0 до 9");
        }
        
        var tuning = lines[1]
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (tuning.Length != 6)
        {
            throw new FileException("Другий рядок має містити 6 нот");
        }
        
        var chordsArray = lines[2].
            Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (chordsArray.Length > 1)
        {
            throw new FileException("Третій рядок має містити 1 акорд");
        }

        return (frets, tuning, chordsArray[0]);
    }

    public static void WriteOutputFile(int possibleWays)
    {
        File.WriteAllText(OutputFileName, possibleWays.ToString());
    }
    
}