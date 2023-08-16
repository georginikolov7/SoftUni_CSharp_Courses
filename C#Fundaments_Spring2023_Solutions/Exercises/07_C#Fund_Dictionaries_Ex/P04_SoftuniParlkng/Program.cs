namespace P04_SoftuniParlkng
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> parkedCars = new Dictionary<string, string>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split();
                string command = input[0];
                string person = input[1];
                if (command == "register")
                {
                    string licensePlate = input[2];
                    RegisterCar(parkedCars, person, licensePlate);
                }
                else if (command == "unregister")
                {
                    UnregisterCar(parkedCars, person);
                }

            }
            foreach (var kvp in parkedCars)
            {
                Console.WriteLine($"{kvp.Key} => {kvp.Value}");
            }
        }

        static void UnregisterCar(Dictionary<string, string> parkedCars, string person)
        {
            if (!parkedCars.ContainsKey(person))
            {
                Console.WriteLine($"ERROR: user {person} not found");
                return;
            }

            parkedCars.Remove(person);
            Console.WriteLine($"{person} unregistered successfully");
        }

        static void RegisterCar(Dictionary<string, string> parkedCars, string person, string licensePlate)
        {
            if (parkedCars.ContainsKey(person))
            {
                Console.WriteLine($"ERROR: already registered with plate number {parkedCars[person]}");
                return;
            }

            parkedCars.Add(person, licensePlate);
            Console.WriteLine($"{person} registered {licensePlate} successfully");
        }
    }
}