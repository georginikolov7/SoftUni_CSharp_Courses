namespace P08_FactorialDevision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n1=int.Parse(Console.ReadLine());
            int n2=int.Parse(Console.ReadLine());
            long fact1 = GetFactorial(n1);
            long fact2 = GetFactorial(n2);
            Console.WriteLine($"{(double)fact1/fact2:f2}");
        }

        private static long GetFactorial(long number)
        {
            long result = 1;
            for (int i = 1; i <= number; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}