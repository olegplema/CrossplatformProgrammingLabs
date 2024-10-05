namespace App;

public static class MatrixService
{
    public static void FillDpMatrix(int[,] dp, int[,] prev, int[,] matrix)
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
                
                dp[i, j] += matrix[i, j];
            }
        }
    } 
    
    public static int FindMinCostRow(int[,] dp)
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
    
    public static int[] RecoverPath(int[,] prev, int minRow, int n)
    {
        int[] path = new int[n];
        int currentRow = minRow;
        for (var j = n - 1; j >= 0; j--)
        {
            path[j] = currentRow + 1;
            currentRow = prev[currentRow, j];
        }
        return path;
    }
}