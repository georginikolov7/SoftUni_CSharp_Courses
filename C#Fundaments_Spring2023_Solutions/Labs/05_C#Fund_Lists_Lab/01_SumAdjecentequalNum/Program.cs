
namespace _01_SumAdjecentequalNum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<double> numbers = Console.ReadLine()
                .Split(" ")
                .Select(double.Parse)
                .ToList();
            for (int i = 0; i < numbers.Count-1; i++)
            {
                if (numbers[i] == numbers[1 + i])
                {
                    numbers[i] += numbers[i + 1];
                    numbers.RemoveAt(i+1);
                    i=-1;
                }
            }
            Console.WriteLine(string.Join(" ", numbers));

        }
    }
}