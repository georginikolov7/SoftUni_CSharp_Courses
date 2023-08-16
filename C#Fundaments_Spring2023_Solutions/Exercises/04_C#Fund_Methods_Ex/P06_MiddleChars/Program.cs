namespace P06_MiddleChars
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input=Console.ReadLine();
            PrintMiddleChar(input);
        }

        static void PrintMiddleChar(string input)
        {
            
            int length=input.Length;
            
            if (length % 2 == 0)
            {
                Console.WriteLine($"{input[length / 2 - 1]}{input[length/2]}");
            }
            else
            {
                Console.WriteLine(input[length/2]);
            }
        }
    }
}