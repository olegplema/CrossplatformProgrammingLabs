namespace App;

public static class FileProcessor
{
    private const string InputFileName = "INPUT.TXT";
    private const string OutputFileName = "OUTPUT.TXT";

    public static (int, List<(int, int)>) ParseInputFile()
    {
        if (!File.Exists(InputFileName))
        {
            throw new FileException($"Файл {InputFileName} не знайдено");
        }
        
        var lines = File.ReadAllLines(InputFileName)
            .Select(static line => line.Trim())
            .Where(static line => !string.IsNullOrWhiteSpace(line))
            .ToArray();
        
        var firstLine = lines[0]
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);
        
        if (firstLine.Length != 2)
        {
            throw new FileException("Перший рядок має містити два числа");
        }

        if (!int.TryParse(firstLine[0], out var n) || !int.TryParse(firstLine[1], out var m))
        {
            throw new FileException("Перший рядок має містити цілi числа");
        }

        if (n < 2 || n > 18)
        {
            throw new FileException("Перше число має бути в межах від 2 до 18");
        }
        
        if (m < 0)
        {
            throw new FileException("Друге число має бути більше за 0");
        }

        if (lines.Length - 1 != m)
        {
            throw new FileException("Введена кількість рядків не відповідає заданій кількості.");
        }
        
        var channels = new List<(int, int)>();
        for (var i = 1; i < lines.Length; i++)
        {
            var row= lines[i]
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (row.Length != 2)
            {
                throw new FileException("В кожному рядку маэ бути 2 числа.");
            }
            
            if (!int.TryParse(row[0], out var u))
            {
                throw new FileException("Вcі значення матриці мають бути цілими числами.");
            }
                
            if (!int.TryParse(row[1], out var v))
            {
                throw new FileException("Вcі значення матриці мають бути цілими числами.");
            }
            
            if (u < 1 || u > n || v < 1 || v > n || u == v)
            {
                throw new FileException($"Некоректний канал зв'язку ({u}, {v})");
            }
            
            if (channels.Contains((u, v)) || channels.Contains((v, u)))
            {
                throw new FileException($"Зв'язок ({u}, {v}) вже існує.");
            }
            
            channels.Add((u, v));
        }
        
        return (n, channels);
    }

    public static void WriteOutputFile(int minStationsCount, List<HashSet<int>> optimalSolutions)
    {
        var result = $"{minStationsCount} {optimalSolutions.Count}\n" +
                        $"{string.Join(" ", optimalSolutions[0].OrderBy(x => x))}";
        File.WriteAllText(OutputFileName, result);
    }
}