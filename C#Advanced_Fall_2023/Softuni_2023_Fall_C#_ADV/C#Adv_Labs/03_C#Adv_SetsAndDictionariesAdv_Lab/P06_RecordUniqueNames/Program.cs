namespace P06_RecordUniqueNames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> set = new HashSet<string>();
            int countOfInputs=int.Parse(Console.ReadLine());
            for (int i = 0; i < countOfInputs; i++)
            {
                string name=Console.ReadLine();
                set.Add(name);
            }
            foreach (string name in set)
            {
                Console.WriteLine(name);
            }
        }
    }
}