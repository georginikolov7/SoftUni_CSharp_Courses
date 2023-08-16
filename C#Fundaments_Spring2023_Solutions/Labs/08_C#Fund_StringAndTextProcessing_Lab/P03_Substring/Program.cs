namespace P03_Substring
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string key=Console.ReadLine();
            string text=Console.ReadLine();
            while (text.Contains(key))
            {
                int startIndex=text.IndexOf(key);
                text=new string(text.Remove(startIndex, key.Length));
            }
            Console.WriteLine(text);
        }
    }
}