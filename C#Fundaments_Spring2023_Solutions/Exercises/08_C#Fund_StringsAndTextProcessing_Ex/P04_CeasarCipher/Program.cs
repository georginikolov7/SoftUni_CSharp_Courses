namespace P04_CeasarCipher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            char[] text = Console.ReadLine().ToCharArray();
            for (int i = 0; i < text.Length; i++)
            {
                text[i] += (char)3;
            }
            Console.WriteLine(new string(text));
        }
    }
}