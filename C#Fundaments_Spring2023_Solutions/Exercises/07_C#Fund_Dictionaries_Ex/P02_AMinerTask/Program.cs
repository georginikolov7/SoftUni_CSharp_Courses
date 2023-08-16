namespace P02_AMinerTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            Dictionary<string,float> resourcesQuantities= new Dictionary<string,float>();
            while ((input = Console.ReadLine()) != "stop")
            {
                float quantity=float.Parse(Console.ReadLine());
                if (!resourcesQuantities.ContainsKey(input))
                {
                    resourcesQuantities.Add(input, quantity);
                }
                else
                {
                    resourcesQuantities[input] += quantity;
                }
            }
            foreach(var kvp in resourcesQuantities)
            {
                Console.WriteLine($"{kvp.Key} -> {kvp.Value}");
            }
        }
    }
}