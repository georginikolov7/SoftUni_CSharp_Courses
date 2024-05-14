namespace P01_Diagonals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            FillMatrix(matrix);

            int sumD1 = 0, sumD2 = 0;
            for (int i = 0; i < n; i++)
            {
                sumD1 += matrix[i, i];
                sumD2 += matrix[i, matrix.GetLength(1) - i - 1];
            }
            Console.WriteLine(Math.Abs(sumD1-sumD2));
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