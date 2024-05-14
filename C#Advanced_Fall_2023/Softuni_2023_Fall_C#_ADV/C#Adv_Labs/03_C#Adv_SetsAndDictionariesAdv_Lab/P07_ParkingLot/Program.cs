namespace P07_ParkingLot
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();
            string command;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split(", ");
                if (tokens[0] == "IN")
                {
                    set.Add(tokens[1]);
                }
                else if (tokens[0] == "OUT")
                {
                    set.Remove(tokens[1]);
                }
            }
            if (set.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (string registration in set)
                {
                    Console.WriteLine(registration);
                }
            }
        }
    }
}