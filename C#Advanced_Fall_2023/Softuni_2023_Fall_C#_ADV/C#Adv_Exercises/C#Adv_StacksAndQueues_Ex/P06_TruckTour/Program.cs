namespace P06_TruckTour
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //3
            //1 5
            //10 3
            //3 4

            int countOfStations = int.Parse(Console.ReadLine());
            Queue<int[]> stations = new Queue<int[]>();
            for (int i = 0; i < countOfStations; i++)
            {
                int[] tokens = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                stations.Enqueue(tokens);
            }
            int j = 0;
            for (; j < stations.Count; j++)
            {
                bool flag = false;      //to check if foreach was broken AKA objective wasn't reached
                int totalFuelInReservoir = 0;
                foreach (int[] station in stations)
                {
                    totalFuelInReservoir+= station[0];
                    int currentDistance = station[1];
                    if (totalFuelInReservoir < currentDistance)
                    {
                        flag = true;
                        break;  //this iteration does not work
                    }
                    totalFuelInReservoir -= currentDistance;
                }
                if (flag==false)
                {
                    break;  //objective reached
                }
                stations.Enqueue(stations.Dequeue());
            }
            Console.WriteLine(j);
        }
    }
}