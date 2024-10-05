using System;
using System.Collections.Generic;
using App;
using Xunit;
using Xunit.Abstractions;

namespace Tests
{
    public class MatrixServiceTests
    {
        private readonly ITestOutputHelper _output;

        public MatrixServiceTests(ITestOutputHelper output) => _output = output;

        [Fact]
        public void FillDpMatrix_ShouldFillMatrixCorrectly()
        {
            int[,] matrix = { { 2, 1, 3 }, { 6, 5, 4 }, { 7, 8, 9 } };
            int[,] dp = new int[3, 3];
            int[,] prev = new int[3, 3];

            MatrixService.FillDpMatrix(dp, prev, matrix);
            
            Assert.Equal(matrix[0, 0], dp[0, 0]);
            Assert.Equal(matrix[1, 0], dp[1, 0]);
            Assert.Equal(matrix[2, 0], dp[2, 0]);
            
            Assert.True(dp[0, 1] >= 0);
            Assert.True(dp[1, 1] >= 0);
            Assert.True(dp[2, 1] >= 0);
            
            _output.WriteLine("FillDpMatrix_ShouldFillMatrixCorrectly - passed");
        }

        [Theory]
        [InlineData(new[] { 7, 8, 9 }, 0, 3)] 
        [InlineData(new[] { 2, 1, 3 }, 1, 3)] 
        [InlineData(new[] { 6, 5, 4 }, 2, 3)] 
        public void FindMinCostRow_ShouldReturnCorrectRow(int[] rowValues, int expectedRow, int columns)
        {
            int[,] dp = new int[3, columns];
            dp[0, columns - 1] = rowValues[0];
            dp[1, columns - 1] = rowValues[1];
            dp[2, columns - 1] = rowValues[2];

            dp[0, 1] = 3; 
            dp[1, 1] = 5;
            dp[2, 1] = 4;
            
            int minRow = MatrixService.FindMinCostRow(dp);

            Assert.Equal(expectedRow, minRow);
            _output.WriteLine($"FindMinCostRow_ShouldReturnCorrectRow - expected: {expectedRow}, actual: {minRow} - passed");
        }

        [Fact]
        public void RecoverPath_ShouldReturnCorrectPath()
        {
            int[,] prev = {
                { 0, 0, 1 },
                { 1, 1, 2 },
                { 2, 2, 2 }
            };
            int minRow = 1;
            int n = 3;

            var path = MatrixService.RecoverPath(prev, minRow, n);

            Assert.Equal(new[] { 3, 3, 2 }, path);
            _output.WriteLine("RecoverPath_ShouldReturnCorrectPath - passed");
        }

        [Fact]
        public void RecoverPath_ShouldReturnPathWithSingleRow()
        {
            int[,] prev = { { 1, 2, 1 }, {2, 1, 2 }, {1, 1, 1} };

            int minRow = 0;

            var path = MatrixService.RecoverPath(prev, minRow, 3);

            Assert.Equal(new[] { 2, 2, 1 }, path);
            _output.WriteLine("RecoverPath_ShouldReturnPathWithSingleRow - passed");
        }

        [Fact]
        public void FindMinCostRow_ShouldReturnCorrectRowIndex_WhenMinimumCostExists()
        {
            int[,] dp = {
                { 10, 20, 30 },
                { 5, 15, 25 },
                { 40, 10, 20 }
            };
            
            int minCostRow = MatrixService.FindMinCostRow(dp);
            
            Assert.Equal(2, minCostRow);
            _output.WriteLine("FindMinCostRow_ShouldReturnCorrectRowIndex_WhenMinimumCostExists - passed");
        }
    }
}
