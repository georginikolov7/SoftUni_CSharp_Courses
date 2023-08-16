using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace P02_Race
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> racersDistances = new Dictionary<string, int>();
            List<string> racerNames = Console.ReadLine().Split(", ").ToList();
            foreach (string racerName in racerNames)
            {
                racersDistances.Add(racerName, 0);
            }
            string patternForLetter = @"[a-zA-Z]";
            string patternForDigits = @"\d";
            string input;
            while ((input = Console.ReadLine()) != "end of race")
            {
                /*can be done without regex like this:
                  string name = new string(input
                    .Where(x => char.IsLetter(x))
                    .ToArray());*/
                StringBuilder sb = new StringBuilder();
                foreach (Match match in Regex.Matches(input, patternForLetter))
                {
                    sb.Append(match.Value);
                }
                if (racersDistances.ContainsKey(sb.ToString()))
                {
                    MatchCollection matchCollection = Regex.Matches(input, patternForDigits);
                    int currentDistance = matchCollection.Select(x => int.Parse(x.Value)).ToArray().Sum();
                    racersDistances[sb.ToString()] += currentDistance;
                }

            }
            PrintTop3(racersDistances);
        }

        static void PrintTop3(Dictionary<string, int> racersDistances)
        {
            List<string> top3Racers = racersDistances
                .OrderByDescending(x => x.Value)
                .Take(3)
                .Select(x=>x.Key)
                .ToList();
            Console.WriteLine($"1st place: {top3Racers[0]}");
            Console.WriteLine($"2nd place: {top3Racers[1]}");
            Console.WriteLine($"3rd place: {top3Racers[2]}");
        }
    }
}