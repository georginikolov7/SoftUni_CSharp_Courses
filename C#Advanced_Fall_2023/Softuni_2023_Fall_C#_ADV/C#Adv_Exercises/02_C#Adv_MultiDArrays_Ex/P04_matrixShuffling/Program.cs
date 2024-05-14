using System.Diagnostics.SymbolStore;

namespace P04_matrixShuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            string[,] matrix = new string[dimensions[0], dimensions[1]];
            matrix = FillMatrix(matrix);

            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                if (!IsValidCommand(command, matrix.GetLength(0), matrix.GetLength(1)))
                {
                    Console.WriteLine("Invalid input!");
                    continue;
                }
                string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);               
                int row1 = int.Parse(tokens[1]);
                int col1 = int.Parse(tokens[2]);
                int row2 = int.Parse(tokens[3]);
                int col2 = int.Parse(tokens[4]);               
                matrix = Swap(row1, col1, row2, col2, matrix);
                PrintMatrix(matrix);
            }
        }

        static bool IsValidCommand(string command, int rows, int cols)
        {
            string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            bool isValidKey = tokens[0] == "swap";
            bool isValidCountOfArgs = tokens.Length == 5;
            if (isValidKey && isValidCountOfArgs)
            {
                int row1 = int.Parse(tokens[1]);
                int col1 = int.Parse(tokens[2]);
                int row2 = int.Parse(tokens[3]);
                int col2 = int.Parse(tokens[4]);
                return row1 >= 0 && row1 < rows && col1 >= 0 && col1 < cols && row2 >= 0 && row2 < rows && col2 >= 0 && col2 < cols;
            }
            return false;
        }

        static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        static string[,] Swap(int row1, int col1, int row2, int col2, string[,] matrix)
        {
            (matrix[row1, col1], matrix[row2, col2]) = (matrix[row2, col2], matrix[row1, col1]);
            return matrix;
        }

        static bool IsInvalidRowIndex(int row, string[,] matrix)
        {
            if (row < 0 || row >= matrix.GetLength(0))
            {
                return true;
            }
            return false;
        }
        static bool IsInvalidColIndex(int col, string[,] matrix)
        {
            if (col < 0 || col >= matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }

        static string[,] FillMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
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