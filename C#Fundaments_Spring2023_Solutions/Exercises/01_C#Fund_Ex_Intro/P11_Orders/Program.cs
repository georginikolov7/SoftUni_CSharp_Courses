using System;
using System.Diagnostics;

namespace P11_Orders
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //((daysInMonth * capsulesCount) * pricePerCapsule)
            
            int ordersCount = int.Parse(Console.ReadLine());
            double total = 0;

            for (int i = 0; i < ordersCount; i++)
            {
                double currSum = 0;
                double pricePerCapsule = double.Parse(Console.ReadLine());
                int days = int.Parse((Console.ReadLine()));
                int capsulesCount = int.Parse((Console.ReadLine()));

                currSum = days * capsulesCount * pricePerCapsule;
                total += currSum;
                Console.WriteLine($"The price for the coffee is: ${currSum:f2}");
            }
            
            Console.WriteLine($"Total: ${total:f2}");
        }
    }
}
