using System.Text.RegularExpressions;

namespace P01_MatchFullName
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b(?<FirstName>[A-Z][a-z]+) (?<SecondName>[A-Z][a-z]+\b)";
            string names = Console.ReadLine();
            //Regex regex = new Regex(pattern);
            //MatchCollection matchCollection = regex.Matches(names);
            //<=>
            MatchCollection matchCollection = Regex.Matches(names, pattern);
            foreach (Match match in matchCollection)
            {
                Console.Write(match.Value + " ");
            }
        }
    }
}