namespace P02_CharMultyplier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split();
            string str1 = input[0];
            string str2 = input[1];
            int length = Math.Min(str1.Length, str2.Length);
            int sum = 0;
            int i = 0;
            for (; i < length; i++)
            {
                sum += str1[i] * str2[i];
            }

            string longerStr = GetLongerString(str1, str2);
            for (; i < longerStr.Length; i++)
            {
                sum += longerStr[i];
            }

            Console.WriteLine(sum);

        }
        static string GetLongerString(string str1, string str2)
        {
            if (str1.Length > str2.Length)
            {
                return str1;
            }

            else return str2;
        }
    }
}