namespace P05_SMS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string text=string.Empty;
            for (int i = 0; i < n; i++)
            {
                int input = int.Parse(Console.ReadLine());
                if (input == 0)
                {
                    text += " "; 
                    continue;
                }
                int length = input.ToString().Length;
                //22 333 666
                int mainNumber = input % 10;
                int offsetFrom0 = (mainNumber - 2) * 3;
                if (mainNumber == 8 || mainNumber == 9) offsetFrom0++;               
                text+=(char)('a' + (offsetFrom0 + length - 1));
            }
            Console.WriteLine(text);
        }
    }
}