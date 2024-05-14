namespace P05_SnakeMoves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            string snakeInput = Console.ReadLine();
            Queue<char> snake = new Queue<char>(snakeInput.ToCharArray());
            char[,] matrix = new char[dimensions[0], dimensions[1]];

            for (int row = 0; row < dimensions[0]; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < dimensions[1]; col++)
                    {
                        matrix[row, col] = snake.Peek();
                        snake.Enqueue(snake.Dequeue());
                    }
                }
                else
                {
                    for (int col = dimensions[1] - 1; col >= 0; col--)
                    {
                        matrix[row, col] = snake.Peek();
                        snake.Enqueue(snake.Dequeue());
                    }
                }
               
            }

            PrintMatrix(matrix);
        }
        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}