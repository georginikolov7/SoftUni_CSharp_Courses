namespace P10_MultiplyEvensByOdds
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int number = Math.Abs(int.Parse(Console.ReadLine()));
            int sumOfOdds = GetSumOfOdds(number);
            int sumOfEvens=GetSumOfEvens(number);
            Console.WriteLine(sumOfEvens*sumOfOdds);
        }

        private static int GetSumOfOdds(int number)
        {
            int sum = 0;
            while (number>0)
            {
                if (number % 10 % 2 != 0)
                {
                    sum += number % 10;
                }
                number /= 10;
            }
            return sum;
        }
        private static int GetSumOfEvens(int number)
        {
            int sum = 0;
            while (number > 0)
            {
                if (number % 10 % 2 == 0)
                {
                    sum += number % 10;
                }
                number /= 10;
            }
            return sum;
        }
    }
}