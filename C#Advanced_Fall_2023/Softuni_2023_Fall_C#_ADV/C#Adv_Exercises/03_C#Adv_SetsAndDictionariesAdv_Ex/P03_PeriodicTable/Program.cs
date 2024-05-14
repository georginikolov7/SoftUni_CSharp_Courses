namespace P03_PeriodicTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedSet<string> set = new();
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                string[] currentCompounds = Console.ReadLine()
                    .Split();
                foreach (string currentCompound in currentCompounds)
                {
                    set.Add(currentCompound);
                }
            }
            foreach (string currentCompound in set)
            {
                Console.Write(currentCompound + " ");
            }
        }
    }
}