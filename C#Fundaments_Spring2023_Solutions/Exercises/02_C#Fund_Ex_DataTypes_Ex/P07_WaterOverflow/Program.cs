namespace P07_WaterOverflow
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfFillings = int.Parse(Console.ReadLine());
            int capacity = 255;
            int totalFilled = 0;
            for (int i = 0; i < numberOfFillings; i++)
            {
                int filling = int.Parse(Console.ReadLine());
                if (filling>capacity)
                {
                    Console.WriteLine("Insufficient capacity!");
                    continue;
                }
                capacity-=filling;
                totalFilled+=filling;
            }
            Console.WriteLine(totalFilled);
        }
    }
}