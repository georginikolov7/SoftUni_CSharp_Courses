namespace P02_SumMatrixCols
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[dimensions[0], dimensions[1]];
            matrix = ReadMatrixRowByRow(matrix);

            for (int i = 0; i < matrix.GetLength(1); i++)
            {
                int columnSum = 0;
                for (int j = 0; j < matrix.GetLength(0); j++)
                {
                    columnSum += matrix[j, i];
                }
                Console.WriteLine(columnSum);
            }
        }
        static int[,] ReadMatrixRowByRow(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                int[] row = Console.ReadLine()
                    .Split()
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