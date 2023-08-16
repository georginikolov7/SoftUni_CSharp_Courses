namespace P02_RepeatStrings
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] strings = Console.ReadLine()
                .Split();
            foreach (string s in strings)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    Console.Write(s);
                }
            }
        }
    }
}