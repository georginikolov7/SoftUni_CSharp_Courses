namespace P05_Digits_Letters_Others
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input=Console.ReadLine();
            string digits=string.Empty;
            string letters=string.Empty;
            string others=string.Empty;
            foreach(char ch in input)
            {
                if (char.IsDigit(ch))
                {
                    digits += ch;
                }
                else if(char.IsLetter(ch))
                {
                    letters += ch;
                }
                else
                {
                    others += ch;
                }
            }

            Console.WriteLine(digits);
            Console.WriteLine(letters);
            Console.WriteLine(others);

        }
    }
}