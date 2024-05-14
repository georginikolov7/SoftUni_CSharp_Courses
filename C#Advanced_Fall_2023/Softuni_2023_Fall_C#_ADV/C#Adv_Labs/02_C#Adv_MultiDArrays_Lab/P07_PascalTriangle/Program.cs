using System.Data;

namespace P07_PascalTriangle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long[][] pascalTriangle = new long[n][];
            pascalTriangle[0] = new long[1] { 1 };   //hardcode first row
            for (int row = 1; row < n; row++)
            {
                pascalTriangle[row] = new long[row + 1];
                for (int col = 0; col < row + 1; col++)
                {
                    if (col > 0)
                    {
                        pascalTriangle[row][col] += pascalTriangle[row - 1][col - 1];

                    }
                    if (col < row)
                    {
                        pascalTriangle[row][col] += pascalTriangle[row - 1][col];

                    }
                }

            }

            PrintTriangle(pascalTriangle);
        }

        static void PrintTriangle(long[][] pascalTriangle)
        {
            for (int row = 0; row < pascalTriangle.Length; row++)
            {
                for (int i = 0; i < pascalTriangle[row].Length; i++)
                {
                    Console.Write(pascalTriangle[row][i] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}