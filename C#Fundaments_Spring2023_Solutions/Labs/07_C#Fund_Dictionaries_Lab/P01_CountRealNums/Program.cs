namespace P01_CountRealNums
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbers=Console.ReadLine().Split().Select(int.Parse).ToArray();
            SortedDictionary<int,int> occurances= new SortedDictionary<int,int>();
            foreach (int number in numbers)
            {
                if (occurances.ContainsKey(number))
                {
                    occurances[number]++;
                }
                else
                {
                    occurances.Add(number, 1);
                }
            }

            foreach (var count in occurances)
            {
                Console.WriteLine($"{count.Key} -> {count.Value}");
            }
        }
    }
}