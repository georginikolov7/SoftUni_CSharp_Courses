namespace P04_SymbolInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];
            matrix = ReadMatrixRowByRow(matrix);

            char soughtChar = char.Parse(Console.ReadLine());
            bool isFound = false;
            int foundRow = 0, foundCol = 0;
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == soughtChar)
                    {
                        isFound = true;
                        foundRow = row;
                        foundCol = col;
                        break;
                    }
                }
                if (isFound)
                {
                    break;

                }
            }
            if (isFound)
            {
                Console.WriteLine($"({foundRow}, {foundCol})");
            }
            else
            {
                Console.WriteLine($"{soughtChar} does not occur in the matrix");
            }
        }
        static char[,] ReadMatrixRowByRow(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                string row = Console.ReadLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];
                }
            }
            return matrix;
        }
    }
}