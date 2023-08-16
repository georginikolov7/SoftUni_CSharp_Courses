namespace P10_TopNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int endNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < endNumber; i++)
            {
                if (IsSumOfDigitsDivisibleBy8(i) && HasOddDigit(i))
                {
                    Console.WriteLine(i);
                }
            }
        }

        static bool HasOddDigit(int num)
        {
            while (num > 0)
            {
                if (num % 10 % 2 != 0)
                {
                    return true;
                }
                num /= 10;
            }
            return false;
        }

        static bool IsSumOfDigitsDivisibleBy8(int num)
        {
            string temp = num.ToString();
            int[] arr = new int[temp.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = temp[i];
            }
            int sum = arr.Sum();
            if (sum % 8 == 0)
            {
                return true;
            }
            else return false;


        }
    }
}