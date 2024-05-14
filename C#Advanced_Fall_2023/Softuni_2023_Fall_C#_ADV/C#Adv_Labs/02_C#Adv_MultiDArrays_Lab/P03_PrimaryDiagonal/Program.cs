namespace P03_PrimaryDiagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            matrix = ReadMatrixRowByRow(matrix);

            //Find sum of pr diagonal:
            int sumOfPrimaryDiagonal = 0;
            for (int i = 0; i < n; i++)
            {
                sumOfPrimaryDiagonal += matrix[i, i];
            }
            Console.WriteLine(sumOfPrimaryDiagonal);
        }
        static int[,] ReadMatrixRowByRow(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] row = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = row[j];
                }
            }
            return matrix;
        }
    }
}