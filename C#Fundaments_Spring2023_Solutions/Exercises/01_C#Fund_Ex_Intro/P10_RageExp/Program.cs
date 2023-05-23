using System;

namespace P10_RageExp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int lostGamesCount = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double dispayPrice = double.Parse(Console.ReadLine());

            int numOfHeadsets = 0;
            int numOfmouses = 0;
            int numOfkeyboards = 0;
            int numOfdispays = 0;
            for (int i = 1; i <= lostGamesCount; i++)
            {
                if (i % 2 == 0)
                {
                    numOfHeadsets++;

                }
                if (i % 3 == 0)
                {
                    numOfmouses++;
                }
                if (i % 2 == 0 && i % 3 == 0)
                {
                    numOfkeyboards++;
                    if (numOfkeyboards % 2 == 0 && numOfkeyboards != 0)
                    {
                        numOfdispays++;
                    }
                }
            }
            double expenses = numOfHeadsets * headsetPrice + numOfmouses * mousePrice + numOfkeyboards * keyboardPrice + numOfdispays * dispayPrice;
            Console.WriteLine($"Rage expenses: {expenses:f2} lv.");
        }

    }
}
