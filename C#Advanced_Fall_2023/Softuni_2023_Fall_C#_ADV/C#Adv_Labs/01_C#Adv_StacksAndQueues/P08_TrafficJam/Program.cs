namespace P08_TrafficJam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int crossRoadCapacity = int.Parse(Console.ReadLine());
            Queue<string> cars= new Queue<string>();
            int carsCount = 0;
            string inputCommand;
            while ((inputCommand = Console.ReadLine()) != "end")
            {
                if (inputCommand == "green")
                {
                    int carsToPass=Math.Min(cars.Count, crossRoadCapacity);
                    for (int i = 0; i < carsToPass; i++)
                    {
                        carsCount++;
                        Console.WriteLine($"{cars.Dequeue()} passed!");
                    }
                    continue;
                }
                cars.Enqueue(inputCommand);
            }
            Console.WriteLine($"{carsCount} cars passed the crossroads.");
        }
    }
}