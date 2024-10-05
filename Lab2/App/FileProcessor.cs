namespace App;

public static class FileProcessor
{
    private const string InputFileName = "INPUT.TXT";
    private const string OutputFileName = "OUTPUT.TXT";

    public static (int m, int n, int[,] matrix) ParseInputFile()
    {
        if (!File.Exists(InputFileName))
        {
            throw new FileException($"Файл {InputFileName} не знайдено");
        }
        
        var lines = File.ReadAllLines(InputFileName)
            .Select(static line => line.Trim())
            .Where(static line => !string.IsNullOrWhiteSpace(line))
            .ToArray();
        
        var sizes = lines[0]
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (sizes.Length != 2)
        {
            throw new FileException("Перший рядок маэ містити два числа");
        }

        if (!int.TryParse(sizes[0], out var m) || !int.TryParse(sizes[1], out var n))
        {
            throw new FileException("Перший рядок має містити цілi числа");
        }

        if (m > 10)
        {
            throw new FileException("Число рядків має бути не більше 10");
        }
        
        if (n > 100)
        {
            throw new FileException("Число стовбців має бути не більше 100");
        }

        if (lines.Length - 1 != m)
        {
            throw new FileException("Введена кількість рядків не відповідає заданій кількості");
        }

        var matrix = new int[m, n];
        for (var i = 1; i < lines.Length; i++)
        {
            if (lines[i].Length != n)
            {
                throw new FileException("Введена кількість стовбців не відповідає заданій кількості");
            }   
            
            var row= lines[i]
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (var j = 0; j < row.Length; j++)
            {
                if (!int.TryParse(row[j], out matrix[i - 1, j]))
                {
                    throw new FileException("Вcі значення матриці мають бути цілими числами");
                }
            }
        }

        return (m, n, matrix);
    }

    public static void WriteOutputFile(int[] result, string total)
    {
        var resultString = String.Join(" ", result); 
        File.WriteAllText(OutputFileName, $"{resultString}{Environment.NewLine}{total}");
    }
    
}