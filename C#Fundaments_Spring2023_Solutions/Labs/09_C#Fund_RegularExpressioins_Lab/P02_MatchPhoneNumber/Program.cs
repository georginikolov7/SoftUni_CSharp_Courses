using System.Text.RegularExpressions;

namespace P02_MatchPhoneNumber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?:\+359 2 \d{3} \d{4})|(?:\+359-2-\d{3}-\d{4})\b";
            string phones = Console.ReadLine();
            MatchCollection matchCollection = Regex.Matches(phones, pattern);
            //foreach (Match match in matchCollection)
            //{
            //    Console.Write(match.Value + ", ");
            //}
            Console.WriteLine(string.Join(", ",matchCollection));
        }
    }
}