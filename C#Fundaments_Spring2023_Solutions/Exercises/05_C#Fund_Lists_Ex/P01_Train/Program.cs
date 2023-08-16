namespace P01_Train
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> wagons = Console.ReadLine()
                .Split().Select(int.Parse).ToList();
            int maxCapacity=int.Parse(Console.ReadLine());
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                int passangers;
                string[] command = input.Split().ToArray();
                switch(command[0])
                {
                    case "Add":
                        passangers = int.Parse(command[1]);
                        wagons.Add(passangers);
                        break;
                    default:
                        passangers = int.Parse(command[0]);
                        FindWagon(wagons, passangers, maxCapacity);
                        break;
                }
            }
            Console.WriteLine(string.Join(" ",wagons));
        }

        static void FindWagon(List<int> wagons, int passangers, int maxCapacity)
        {
            for (int i = 0; i < wagons.Count; i++)
            {
                if (wagons[i] + passangers <= maxCapacity)
                {
                    wagons[i] += passangers;
                    return;
                }
            }
        }
    }
}