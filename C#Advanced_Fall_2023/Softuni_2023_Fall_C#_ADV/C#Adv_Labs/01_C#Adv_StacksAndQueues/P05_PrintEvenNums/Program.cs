

namespace P05_PrintEvenNums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> ints = new Queue<int>(Console.ReadLine()
                .Split()
                .Select(int.Parse));
            List<int> list = new List<int>();
            while(ints.Count > 0)
            {
                int current=ints.Dequeue();
                if (current % 2 == 0)
                {
                    list.Add(current);
                }               
            }
            Console.WriteLine(string.Join(", ",list));
        }
    }
}