internal class Program
{
    private static void Main(string[] args)
    {
        List<int> list = Console.ReadLine()
           .Split(", ", StringSplitOptions.RemoveEmptyEntries)
           .Select(int.Parse)
           .Where(x=>x%2==0)
           .OrderBy(x=>x)
           .ToList();
        Console.WriteLine(string.Join(", ",list));
     
    }
}