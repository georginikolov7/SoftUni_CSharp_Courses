namespace P02_SquaresInMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            char[,] matrix = new char[dimensions[0], dimensions[1]];
            matrix = FillMatrix(matrix);

            //Find 2*2 squares of equal chars:
            int countOfSquares = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1]
                        && matrix[row, col] == matrix[row + 1, col]
                        && matrix[row, col] == matrix[row + 1, col + 1])
                    {
                        countOfSquares++;
                    }
                }
            }
            Console.WriteLine(countOfSquares);


            static char[,] FillMatrix(char[,] matrix)
            {
                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    char[] currentRow = Console.ReadLine()
                        .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                        .Select(x => char.Parse(x))
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
}