namespace P04_EvenOccurances
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, int> numbersOccurances = new();
            int count = int.Parse(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                int num = int.Parse((Console.ReadLine()));
                if (!numbersOccurances.ContainsKey(num))
                {
                    numbersOccurances.Add(num, 1);
                }
                else
                {
                    numbersOccurances[num]++;

                }
            }
            Console.WriteLine(numbersOccurances
            .FirstOrDefault(x => x.Value % 2 == 0)
            .Key);
        }
    }
}