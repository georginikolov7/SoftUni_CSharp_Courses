using System.ComponentModel;

namespace P04_FastFood
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int quantityOfFood = int.Parse(Console.ReadLine());

            Queue<int> orders = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));
            int biggestOrder = orders.Max();
            while (orders.Count > 0 && quantityOfFood > 0)
            {
                int currentOrder = orders.Peek();
                if (currentOrder > quantityOfFood)
                {
                    break;
                }
                quantityOfFood -= currentOrder;
                orders.Dequeue();
            }
            Console.WriteLine(biggestOrder);
            if (orders.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ",orders)}");
            }
        }
    }
}