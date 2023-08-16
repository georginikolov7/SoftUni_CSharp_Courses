namespace Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = new List<string> { "pesho", "gosho" };
            names.Insert(names.IndexOf("gosho") + 1, "stamat");
            Console.WriteLine(string.Join(" ",names));
        }
    }
}