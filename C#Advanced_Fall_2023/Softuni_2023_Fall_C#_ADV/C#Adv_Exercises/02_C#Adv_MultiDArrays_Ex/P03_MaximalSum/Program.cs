namespace P05_SquareWithMaxSum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int[,] matrix = new int[dimensions[0], dimensions[1]];
            matrix = ReadMatrixRowByRow(matrix);
            int startRow = 0;
            int startCol = 0;
            int maxSum = int.MinValue;
            int sizeOfSquare = 3;

            //Iterate over matrix and find square: (startIndexes and sum)
            for (int row = 0; row < matrix.GetLength(0) - sizeOfSquare + 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - sizeOfSquare + 1; col++)
                {
                    int currentSum = getSumOfSquare(sizeOfSquare, matrix, row, col);
                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        startRow = row;
                        startCol = col;
                    }
                }

            }

            PrintSquare(matrix, sizeOfSquare, startRow, startCol, maxSum);
        }

        static int getSumOfSquare(int n, int[,] matrix, int startRow, int StartCol)
        {
            int sum = 0;
            for (int row = startRow; row < startRow + n; row++)
            {
                for (int col = StartCol; col < StartCol + n; col++)
                {
                    sum += matrix[row, col];
                }
            }
            return sum;
        }

        static int[,] ReadMatrixRowByRow(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] row = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];
                }
            }
            return matrix;
        }
        static void PrintSquare(int[,] matrix, int sizeOfSquare, int startRow, int startCol, int sum)
        {
            Console.WriteLine($"Sum = {sum}");
            for (int row = startRow; row < startRow + sizeOfSquare; row++)
            {
                for (int col = startCol; col < startCol + sizeOfSquare; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}