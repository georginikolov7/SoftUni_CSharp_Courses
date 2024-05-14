
using System.Text.RegularExpressions;
namespace Bombs
{
    class Program
    {
        static int[,] matrix;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            matrix = new int[n, n];
            FillMatrix(matrix);
            string pattern = @"(?<row>\d+),(?<col>\d+)";
            string coordsInput = Console.ReadLine();
            MatchCollection mc = Regex.Matches(coordsInput, pattern);
            ExplodeBombs(mc);

            int countOfLiveCells = 0;
            int sumOfLiveCells = 0;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        countOfLiveCells++;
                        sumOfLiveCells += matrix[row, col];
                    }
                }
            }
            Console.WriteLine($"Alive cells: {countOfLiveCells}");
            Console.WriteLine($"Sum: {sumOfLiveCells}");
            PrintMatrix();
        }

        static void PrintMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        static void ExplodeBombs(MatchCollection mc)
        {
            foreach (Match match in mc)
            {
                int row = int.Parse(match.Groups["row"].Value);
                int col = int.Parse(match.Groups["col"].Value);
                int bombValue = matrix[row, col];
                if (bombValue <= 0) //ALREADY DED
                {
                    continue;
                }

                //Explode top row:
                if (row >= 1)
                {
                    ExplodeRow(row - 1, col - 1, bombValue);
                }
                //Explode same row:
                ExplodeRow(row, col - 1, bombValue);
                //Explode bottom row:
                if (row < matrix.GetLength(0) - 1)
                {
                    ExplodeRow(row + 1, col - 1, bombValue);
                }
                matrix[row, col] = 0;   //bomb exploded
                //i-1,j-1
                //i-1,j
                //i-1;j+1
                //i;j-1
                //i;j+1
                //i+1;j-1
                //i+1;j
                //i+1;j+1
            }
        }

        static void ExplodeRow(int row, int startCol, int bombVal)
        {
            for (int i = startCol; i < startCol + 3; i++)
            {
                if (IsValidCol(i) && matrix[row, i] > 0)
                {
                    matrix[row, i] -= bombVal;
                }
            }
        }

        static bool IsValidCol(int index)
        {
            return index >= 0 && index < matrix.GetLength(1);
        }

        static int[,] FillMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = currentRow[col];
                }
            }
            return matrix;
        }
    }
}
