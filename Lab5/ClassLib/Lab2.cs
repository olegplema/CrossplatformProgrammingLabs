namespace ClassLib;

public class Lab2
{
    public static string Execute(string inputPath)
    {
        try
        {
            var (m, n, matrix) = ParseInputFile(inputPath);

            int[,] prev = new int[m, n], dp = new int[m, n];

            FillDpMatrix(dp, prev, matrix);
            
            var minCostRow = FindMinCostRow(dp);
            var minCost = dp[minCostRow, n - 1];

            var result = RecoverPath(prev, minCostRow, n);
            var resultString = String.Join(" ", result); 
            return $"{resultString}{Environment.NewLine}{minCost}";
        }
        catch (Exception e)
        {
            return "Something went wrong: " + e.Message;
        }
    }
    
    private static (int m, int n, int[,] matrix) ParseInputFile(string inputFileName)
    {
        if (!File.Exists(inputFileName))
        {
            throw new FileException($"File {inputFileName} not found");
        }
        
        var lines = File.ReadAllLines(inputFileName)
            .Select(static line => line.Trim())
            .Where(static line => !string.IsNullOrWhiteSpace(line))
            .ToArray();
        
        var sizes = lines[0]
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        if (sizes.Length != 2)
        {
            throw new FileException("The first line must contain two numbers");
        }

        if (!int.TryParse(sizes[0], out var m) || !int.TryParse(sizes[1], out var n))
        {
            throw new FileException("The first line must contain integers");
        }

        if (m > 10)
        {
            throw new FileException("The number of lines must not exceed 10");
        }
        
        if (n > 100)
        {
            throw new FileException("The number of columns must not exceed 100");
        }

        if (lines.Length - 1 != m)
        {
            throw new FileException("The entered number of rows does not match the expected number");
        }

        var matrix = new int[m, n];
        for (var i = 1; i < lines.Length; i++)
        {
            var row= lines[i]
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (row.Length != n)
            {
                throw new FileException("The entered number of columns does not match the expected number");
            }   

            for (var j = 0; j < row.Length; j++)
            {
                if (!int.TryParse(row[j], out matrix[i - 1, j]))
                {
                    throw new FileException("All values in the matrix must be integers");
                }
            }
        }

        return (m, n, matrix);
    }
    
    private static void FillDpMatrix(int[,] dp, int[,] prev, int[,] matrix)
    {
        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            dp[i, 0] = matrix[i, 0];
        }
        
        for (var j = 1; j < matrix.GetLength(1); j++)
        {
            for (var i = 0; i < matrix.GetLength(0); i++)
            {
                dp[i, j] = dp[i, j - 1];
                prev[i, j] = i;
                
                if (i > 0 && dp[i, j] > dp[i - 1, j - 1])
                {
                    dp[i, j] = dp[i - 1, j - 1];
                    prev[i, j] = i - 1;
                }

                
                if (i < matrix.GetLength(0) - 1 && dp[i, j] > dp[i + 1, j - 1])
                {
                    dp[i, j] = dp[i + 1, j - 1];
                    prev[i, j] = i + 1;
                }

                try
                {
                    checked
                    {
                        dp[i, j] += matrix[i, j];
                    }

                    if (dp[i, j] > 536870911 || dp[i, j] < -536870912)
                    {
                        throw new OverflowException();
                    }
                }
                catch (OverflowException)
                {
                    throw new OverflowException("The weight of the path exceeds 30 bits");
                }
            }
        }
    } 
    
    private static int FindMinCostRow(int[,] dp)
    {
        var minRow = 0;
        for (var i = 1; i < dp.GetLength(0); i++)
        {
            if (dp[i, dp.GetLength(1) - 1] < dp[minRow, dp.GetLength(1) - 1])
            {
                minRow = i;
            }
        }
        return minRow;
    }
    
    private static int[] RecoverPath(int[,] prev, int minRow, int n)
    {
        var path = new int[n];
        var currentRow = minRow;
        for (var j = n - 1; j >= 0; j--)
        {
            path[j] = currentRow + 1;
            currentRow = prev[currentRow, j];
        }
        return path;
    }
}