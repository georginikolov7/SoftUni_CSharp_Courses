namespace P06_JaggedArrayMod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfRows = int.Parse(Console.ReadLine());
            int[][] jagged = new int[countOfRows][];
            for (int i = 0; i < countOfRows; i++)
            {
                int[] inputLine = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                jagged[i] = inputLine;
            }

            //Read and execute commands:
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split();
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                int value = int.Parse(tokens[3]);
                if (InvalidIndexes(jagged, row, col))
                {
                    Console.WriteLine("Invalid coordinates");
                    continue;
                }
                switch (tokens[0])
                {
                    case "Add":
                        AddElement(jagged, row, col, value);
                        break;
                    case "Subtract":
                        SubtractElement(jagged, row, col, value);
                        break;
                }
            }

            //Print jagged Array:
            PrintJaggedArray(jagged);

        }

        static void PrintJaggedArray(int[][] jagged)
        {
            for (int i = 0; i < jagged.Length; i++)
            {
                Console.WriteLine(string.Join(" ", jagged[i]));
            }
        }

        static void AddElement(int[][] jagged, int row, int col, int value)
        {
            jagged[row][col] += value;
        }

        static void SubtractElement(int[][] jagged, int row, int col, int value)
        {
            jagged[row][col] -= value;
        }

        static bool InvalidIndexes(int[][] jagged, int row, int col)
        {
            if (row >= jagged.Length || row < 0 || col >= jagged[row].Length || col < 0)
            {
                return true;
            }


            return false;
        }
    }
}