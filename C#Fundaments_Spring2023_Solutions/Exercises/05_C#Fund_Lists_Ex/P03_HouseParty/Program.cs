namespace P03_HouseParty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numOfCommands = int.Parse(Console.ReadLine());
            List<string> guests = new List<string>();
            for (int i = 0; i < numOfCommands; i++)
            {
                string[] command = Console.ReadLine().Split().ToArray();
                //"{name} is going!
                //"{name} is not going!
                string name = command[0];
                if (command[command.Length - 2] == "is")
                {
                    if (IsOnList(guests, name))
                    {
                        Console.WriteLine($"{name} is already in the list!");
                    }
                    else
                    {
                        guests.Add(name);
                    }
                }
                else
                {
                    if (IsOnList(guests, name))
                    {
                        guests.Remove(name);
                    }
                    else
                    {
                        Console.WriteLine($"{name} is not in the list!");
                    }
                }
            }
            foreach(string name in guests)
            {
                Console.WriteLine(name);
            }
        }
        static bool IsOnList(List<string> guests, string name)
        {
            return guests.Contains(name);
        }
    }
}