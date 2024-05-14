namespace P10_RadioactiveMutantVampireBunnies
{
    internal class Program
    {
        static char[,] field;
        static int playerRow, playerCol;
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            field = new char[dimensions[0], dimensions[1]];
            FillMatrix();

            string directionSequence = Console.ReadLine();

            foreach (char dir in directionSequence)
            {
                int oldPlayerRow = playerRow;
                int oldPlayerCol = playerCol;
                switch (dir)
                {
                    case 'U':
                        playerRow -= 1;
                        break;
                    case 'D':
                        playerRow += 1;
                        break;
                    case 'L':
                        playerCol -= 1;
                        break;
                    case 'R':
                        playerCol += 1;
                        break;
                }
                SpreadBunnies();
                if (playerRow < 0
                    || playerRow >= field.GetLength(0)
                    || playerCol < 0
                    || playerCol >= field.GetLength(1))
                {
                    //won
                    PrintMatrix();
                    Console.WriteLine($"won: {oldPlayerRow} {oldPlayerCol}");
                    break;
                }
                if (field[playerRow, playerCol] == 'B')
                {
                    PrintMatrix();
                    Console.WriteLine($"dead: {playerRow} {playerCol}");
                    break;
                }

            }
        }
        static void PrintMatrix()
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    Console.Write(field[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void SpreadBunnies()
        {
            Queue<string> bunnyPositions = new Queue<string>();
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] == 'B')
                    {
                        bunnyPositions.Enqueue($"{i},{j}");

                    }
                }
            }
            while(bunnyPositions.Count>0)
            {
                int[] currentCoords = bunnyPositions.Dequeue().Split(',')
                    .Select(int.Parse)
                    .ToArray();
                int row = currentCoords[0];
                int col = currentCoords[1];

                if (isValidRow(row - 1))
                {

                    field[row - 1, col] = 'B';
                }
                if (isValidRow(row + 1))
                {

                    field[row + 1, col] = 'B';
                }
                if (isValidCol(col - 1))
                {

                    field[row, col - 1] = 'B';
                }
                if (isValidCol(col + 1))
                {

                    field[row, col + 1] = 'B';
                }

            }

        }

        static bool isValidRow(int v)
        {
            return v >= 0 && v < field.GetLength(0);
        }

        static bool isValidCol(int v)
        {
            return v >= 0 && v < field.GetLength(1);
        }

        static void FillMatrix()
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                string currentRow = Console.ReadLine();
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = currentRow[j];
                    if (currentRow[j] == 'P')   //found player position
                    {
                        playerRow = i;
                        playerCol = j;
                        field[i, j] = '.';
                    }
                }
            }
        }
    }
}