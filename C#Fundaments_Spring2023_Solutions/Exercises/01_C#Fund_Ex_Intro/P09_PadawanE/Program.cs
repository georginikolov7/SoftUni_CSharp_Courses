using System;

namespace P09_PadawanE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            float budget = float.Parse(Console.ReadLine());
            int countOfPadawans = int.Parse(Console.ReadLine());
            float saberPrice = float.Parse(Console.ReadLine());
            float robePrice = float.Parse(Console.ReadLine());
            float beltPrice = float.Parse(Console.ReadLine());

            float saberTotal = (float)Math.Ceiling(1.10 * countOfPadawans) * saberPrice;
            float beltTotal = (countOfPadawans - countOfPadawans / 6) * beltPrice;
            float totalPrice = saberTotal + beltTotal + countOfPadawans * robePrice;
            // 20/6 = 3
            if (totalPrice > budget)
            {
                Console.WriteLine($"John will need {totalPrice-budget:f2}lv more.");
            }
            else
            {
                Console.WriteLine($"The money is enough - it would cost {totalPrice:f2}lv.");
            }
        }
    }
}
