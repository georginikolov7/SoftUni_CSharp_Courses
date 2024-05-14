namespace P09_SoftUniExamResults
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> participantsPoints = new();
            Dictionary<string, int> languageSubmissions = new();
            string input;
            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] tokens = input.Split("-", StringSplitOptions.RemoveEmptyEntries);
                //"{username}-{language}-{points}"
                string name = tokens[0];
                if (tokens[1] == "banned")
                {
                    participantsPoints.Remove(name);
                    continue;
                }
                string language = tokens[1];
                int points = int.Parse(tokens[2]);
                if (!participantsPoints.ContainsKey(name))
                {
                    participantsPoints[name] = points;
                }
                else if (points > participantsPoints[name])
                {
                    participantsPoints[name] = points;
                }

                //Language dictionary
                if (!languageSubmissions.ContainsKey(language))
                {
                    languageSubmissions[language] = 0;
                }
                languageSubmissions[language]++;
            }

            //Print:
            Console.WriteLine("Results:");
            foreach (var kvp in participantsPoints.OrderByDescending(x => x.Value)
                .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} | {kvp.Value}");
            }
            Console.WriteLine("Submissions:");
            foreach (var kvp in languageSubmissions.OrderByDescending(x => x.Value)
               .ThenBy(x => x.Key))
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value}");
            }
        }
    }
}