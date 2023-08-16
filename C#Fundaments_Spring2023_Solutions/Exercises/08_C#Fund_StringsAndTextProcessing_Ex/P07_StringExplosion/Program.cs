using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace P07_StringExplosion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //StringBuilder sb = new StringBuilder();
            string input = Console.ReadLine();
            Console.WriteLine(ProcessExplosions(input));
        }

        private static string ProcessExplosions(string? input)
        {
            StringBuilder result = new StringBuilder();
            int strength = 0;
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '>')
                {
                    result.Append(input[i]);
                    strength += int.Parse(input[i + 1].ToString());
                }
                else if (strength == 0)
                {
                    result.Append(input[i]);
                }
                else
                {
                    strength--;
                }
            }
            return result.ToString();
        }
    }
}