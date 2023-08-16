using System.Text.RegularExpressions;

namespace P03_MatchDates
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b(?<Day>\d{2})([\/.-])(?<Month>[A-Z][a-z]{2})\1(?<Year>\d{4})";
            string input = Console.ReadLine();
            MatchCollection matchCollection =Regex.Matches(input, pattern);
            foreach (Match match in matchCollection)
            {
                Console.WriteLine($"Day: {match.Groups["Day"].Value}, Month: {match.Groups["Month"].Value}, Year: {match.Groups["Year"].Value}");
            }
        }
    }
}