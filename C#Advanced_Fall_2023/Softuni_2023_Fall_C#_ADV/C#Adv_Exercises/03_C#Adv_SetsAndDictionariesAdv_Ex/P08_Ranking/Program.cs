
namespace Ranking
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> contestsPaswords = new Dictionary<string, string>();
            string input;
            while ((input = Console.ReadLine()) != "end of contests")
            {
                //{contest}:{password for contest}
                string[] tokens = input.Split(":", StringSplitOptions.RemoveEmptyEntries);
                if (!contestsPaswords.ContainsKey(tokens[0]))
                {
                    contestsPaswords.Add(tokens[0], tokens[1]);
                }
            }
            SortedDictionary<string, Dictionary<string, int>> participantsContests = new SortedDictionary<string, Dictionary<string, int>>();
            // "end of submissions"
            while ((input = Console.ReadLine()) != "end of submissions")
            {
                //"{contest}=>{password}=>{username}=>{points}"
                string[] tokens = input.Split("=>", StringSplitOptions.RemoveEmptyEntries);
                string currentContest = tokens[0];
                string currentPassword = tokens[1];
                //Check validity of contest and password:
                if (!contestsPaswords.ContainsKey(currentContest) || currentPassword != contestsPaswords[currentContest])
                {
                    continue;
                }
                string currentUser = tokens[2];
                int currentPoints = int.Parse(tokens[3]);
                if (!participantsContests.ContainsKey(currentUser))
                {
                    participantsContests.Add(currentUser, new Dictionary<string, int>());
                }
                if (!participantsContests[currentUser].ContainsKey(currentContest))
                {
                    participantsContests[currentUser].Add(currentContest, currentPoints);
                }
                else if (currentPoints > participantsContests[currentUser][currentContest])
                {
                    participantsContests[currentUser][currentContest] = currentPoints;
                }
            }

            string bestParticipant = participantsContests
                .OrderByDescending(x => x.Value.Values.Sum())
                .First().Key;
            int bestParticipantPoints = participantsContests[bestParticipant].Values.Sum();
            Console.WriteLine($"Best candidate is {bestParticipant} with total {bestParticipantPoints} points.");
            Console.WriteLine("Ranking:");
            foreach (var participant in participantsContests)
            {
                Console.WriteLine(participant.Key);
                Dictionary<string, int> currentParticipant = participant.Value.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
                foreach (var contest in currentParticipant)
                {
                    Console.WriteLine($"#  {contest.Key} -> {contest.Value}");
                }
            }
        }
    }
}
