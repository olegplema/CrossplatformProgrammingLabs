using App;

int m;
int n;
int[,] matrix;
try
{
    (m, n, matrix) = FileProcessor.ParseInputFile();
}
catch (Exception e)
{
    Console.WriteLine("Виникла помилка: " + e.Message);
    return;
}

int[,] prev = new int[m,n], dp = new int[m,n];

try
{
    MatrixService.FillDpMatrix(dp, prev, matrix);
}
catch (Exception e)
{
    Console.WriteLine("Виникла помилка: " + e.Message);
    return;
}

var minCostRow = MatrixService.FindMinCostRow(dp);
var minCost = dp[minCostRow, n - 1];

var result = MatrixService.RecoverPath(prev, minCostRow, n);

try
{
    FileProcessor.WriteOutputFile(result, minCost);
}
catch (Exception e)
{
    Console.WriteLine("Виникла помилка: " + e.Message);
}