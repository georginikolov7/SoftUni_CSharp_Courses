namespace P03_CharsInRange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            if (secondChar < firstChar)
            {
                (firstChar, secondChar) = (secondChar, firstChar);
            }
            PrintAllCharsInbetween(firstChar, secondChar);
        }
        static void PrintAllCharsInbetween(char firstChar, char secondChar)
        {
            for (int i = firstChar + 1; i < secondChar; i++)
            {
                Console.Write((char)i + " ");
            }
        }
    }
}