namespace P02_VowelsCount
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            PrintNumOfVowels(input);
        }

        private static void PrintNumOfVowels(string input)
        {
            int numOfVows = 0;
            input = input.ToLower();
            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case 'a':
                    case 'e':
                    case 'u':
                    case 'i':
                    case 'o':
                        numOfVows++;
                        break;
                }
            }
            Console.WriteLine(numOfVows);
        }
    }
}