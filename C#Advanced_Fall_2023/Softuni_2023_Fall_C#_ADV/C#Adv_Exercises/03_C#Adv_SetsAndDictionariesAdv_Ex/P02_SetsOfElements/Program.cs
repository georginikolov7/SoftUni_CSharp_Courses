using System.Linq;

namespace P02_SetsOfElements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            HashSet<int> set1 = new HashSet<int>();
            HashSet<int> set2 = new HashSet<int>();
            for (int i = 0; i < sizes[0]; i++)
            {
                set1.Add(int.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < sizes[1]; i++)
            {
                set2.Add(int.Parse(Console.ReadLine()));
            }
            //foreach (int num in set1)
            //{
            //    if (set2.Contains(num))
            //    {
            //        Console.Write(num + " ");
            //    }
            //}
            set1.IntersectWith(set2);
            Console.WriteLine(string.Join(" ",set1));
        }
    }
}