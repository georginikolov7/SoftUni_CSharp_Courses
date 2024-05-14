using System.ComponentModel;

namespace P06_JaggedArrayManipulator
{
    internal class Program
    {
        static int[][] jagged;
        static void Main(string[] args)
        {
            //Read initial jagged:
            int countOfRows = int.Parse(Console.ReadLine());
            jagged = new int[countOfRows][];
            for (int i = 0; i < countOfRows; i++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                jagged[i] = currentRow;
            }
            //Analyze and multiply/divide:
            AnalyzeJagged(jagged);

            //Start reading commands:
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split();
                int row = int.Parse(tokens[1]);
                int col = int.Parse(tokens[2]);
                if (!AreValidIndexes(row, col))
                {
                    continue;
                }
                switch (tokens[0])
                {
                    case "Add":
                        Add(row, col, int.Parse(tokens[3]));
                        break;
                    case "Subtract":
                        Subtract(row, col, int.Parse(tokens[3]));
                        break;
                }
            }

            //Print:
            PrintJagged();
        }

        static void PrintJagged()
        {
            for (int i = 0; i < jagged.Length; i++)
            {
                Console.WriteLine(string.Join(" ", jagged[i]));
            }
        }

        static bool AreValidIndexes(int row, int col)
        {
            bool isRowValid = row >= 0 && row < jagged.Length;
            if (isRowValid)
            {
                return col >= 0 && col < jagged[row].Length;
            }
            return false;
        }

        private static void Add(int row, int col, int val)
        {
            jagged[row][col] += val;
        }
        static void Subtract(int row, int col, int val)
        {
            jagged[row][col] -= val;
        }

        static void AnalyzeJagged(int[][] jagged)
        {
            for (int i = 0; i < jagged.Length - 1; i++)
            {
                if (jagged[i].Length == jagged[i + 1].Length)
                {
                    MultiplyEachValueBy2(i);
                    MultiplyEachValueBy2(i + 1);
                }
                else
                {
                    DivideEachValueBy2(i);
                    DivideEachValueBy2(i + 1);
                }
            }
        }

        static void MultiplyEachValueBy2(int row)
        {
            for (int i = 0; i < jagged[row].Length; i++)
            {
                jagged[row][i] *= 2;
            }
        }
        static void DivideEachValueBy2(int row)
        {
            for (int i = 0; i < jagged[row].Length; i++)
            {
                jagged[row][i] /= 2;
            }
        }
    }
}