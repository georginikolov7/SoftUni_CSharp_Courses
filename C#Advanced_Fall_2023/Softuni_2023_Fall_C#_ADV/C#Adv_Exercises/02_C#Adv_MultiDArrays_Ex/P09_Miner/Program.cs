using System.Reflection.Metadata;

namespace P09_Miner
{
    internal class Program
    {
        static char[,] field;
        static int rowOfMiner, colOfMiner;
        static int totalCoal, collectedCoal = 0;
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            field = new char[size, size];
            FillMatrix();

            AnalyzeField(); //finds count of coal and position of miner
            foreach (string command in commands)
            {
                ExecuteCommand(command);
            }
            Console.WriteLine($"{totalCoal - collectedCoal} coals left. ({rowOfMiner}, {colOfMiner})");
        }

        static void AnalyzeField()
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] == 's')
                    {
                        rowOfMiner = i;
                        colOfMiner = j;
                        
                    }
                    else if (field[i, j] == 'c')
                    {
                        totalCoal++;
                    }
                }
            }
        }

        static void ExecuteCommand(string command)
        {
            //up  down left right
            switch (command)
            {
                case "up":
                    if (IsValidIndex(rowOfMiner - 1))
                    {
                        field[rowOfMiner, colOfMiner] = '*';
                        rowOfMiner--;
                    }
                    break;
                case "down":
                    if (IsValidIndex(rowOfMiner + 1))
                    {
                        field[rowOfMiner, colOfMiner] = '*';
                        rowOfMiner++;
                    }
                    break;
                case "left":
                    if (IsValidIndex(colOfMiner - 1))
                    {
                        field[rowOfMiner, colOfMiner] = '*';
                        colOfMiner--;
                    }
                    break;
                case "right":
                    if (IsValidIndex(colOfMiner + 1))
                    {
                        field[rowOfMiner, colOfMiner] = '*';
                        colOfMiner++;
                    }
                    break;
            }

            //check the new position:
            switch (field[rowOfMiner, colOfMiner])
            {
                case 'c':
                    collectedCoal++;
                    field[rowOfMiner, colOfMiner] = '*';
                    if (collectedCoal == totalCoal)
                    {
                        Console.WriteLine($"You collected all coals! ({rowOfMiner}, {colOfMiner})");
                        System.Environment.Exit(0);
                    }
                    break;
                case 'e':
                    Console.WriteLine($"Game over! ({rowOfMiner}, {colOfMiner})");
                    System.Environment.Exit(0);
                    break;
            }

        }

        static bool IsValidIndex(int index)
        {
            return index >= 0 && index < field.GetLength(1);
        }


        static void FillMatrix()
        {
            for (int i = 0; i < field.GetLength(0); i++)
            {
                char[] currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => char.Parse(x))
                    .ToArray();
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    field[i, j] = currentRow[j];
                }
            }
        }
    }
}