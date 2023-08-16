using System.Text;
using System.Text.RegularExpressions;

namespace P04_StarEnigma
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> attackedPlanets = new List<string>();
            List<string> destroyedPlanets = new List<string>();
            string pattern = @"@(?<planetName>[a-zA-Z]+)(?:[^@\-:!>]*?):(?:[^@\-:!>]*?)(?<population>\d+)(?:[^@\-:!>]*?)!(?:[^@\-:!>]*?)(?<attackType>[AD])(?:[^@\-:!>]*?)!(?:[^@\-:!>]*?)->(?:[^@\-:!>]*?)(?<soldierCount>\d+)";
            int messagesCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < messagesCount; i++)
            {
                string message = Console.ReadLine();
                //Decrypt message:
                message = new string(Decrypt(message));

                //take message elements and add to lists:
                Match match = Regex.Match(message, pattern);
                if (match.Success)
                {
                    ExtractInfo(match, attackedPlanets, destroyedPlanets);
                }
            }

            PrintPlanets(attackedPlanets, destroyedPlanets);
        }

        private static void ExtractInfo(Match match, List<string> attackedPlanets, List<string> destroyedPlanets)
        {
            string planetName = match.Groups["planetName"].Value;
            int population = int.Parse(match.Groups["population"].Value);
            char type = char.Parse(match.Groups["attackType"].Value);
            if (type == 'A')
            {
                attackedPlanets.Add(planetName);
            }
            else if (type == 'D')
            {
                destroyedPlanets.Add(planetName);
            }
        }

        static string Decrypt(string message)
        {
            StringBuilder decryptedMessage = new StringBuilder();

            string keyPattern = @"[STARstar]";

            MatchCollection matchCollection = Regex.Matches(message, keyPattern);
            int key = matchCollection.Count;

            foreach (char c in message)
            {
                decryptedMessage.Append((char)(c - key));
            }

            return decryptedMessage.ToString();
        }
        static void PrintPlanets(List<string> attackedPlanets, List<string> destroyedPlanets)
        {
            Console.WriteLine($"Attacked planets: {attackedPlanets.Count}");
            foreach (string planet in attackedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planet}");
            }

            Console.WriteLine($"Destroyed planets: {destroyedPlanets.Count}");
            foreach (string planet in destroyedPlanets.OrderBy(x => x))
            {
                Console.WriteLine($"-> {planet}");
            }
        }

    }
}