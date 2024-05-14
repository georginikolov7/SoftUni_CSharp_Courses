
namespace P07_TheVLogger
{
    internal class Program
    {
        static Dictionary<string, Dictionary<string, HashSet<string>>> vloggers = new();
        static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "Statistics")
            {
                string[] commandTokens = input.Split();
                switch (commandTokens[1])
                {
                    case "joined":
                        AddToDictionary(commandTokens[0]);
                        break;
                    case "followed":
                        FollowVlogger(commandTokens[0], commandTokens[2]);
                        break;

                }
            }
            PrintResults();
        }

        static void PrintResults()
        {
            //On the first line, print the total count of vloggers:
            Console.WriteLine($"The V-Logger has a total of {vloggers.Count()} vloggers in its logs.");

            //Sort dictionary according to instructions:                        
            vloggers = vloggers.OrderByDescending(x => x.Value["followers"].Count())
                .ThenBy(x => x.Value["following"].Count())
                .ToDictionary(pair => pair.Key,
                              pair => pair.Value);
            int count = 1;
            foreach (var kvp in vloggers)
            {
                int currentFollowers = kvp.Value["followers"].Count();
                int currentFollowing = kvp.Value["following"].Count();
                Console.WriteLine($"{count}. {kvp.Key} : {currentFollowers} followers, {currentFollowing} following");
                if (count == 1)
                {

                    HashSet<string> followers = new HashSet<string>(kvp.Value["followers"]);
                    foreach (string f in followers.OrderBy(x => x))
                    {
                        Console.WriteLine($"*  {f}");
                    }
                }
                count++;
            }
        }

        static void FollowVlogger(string firstVlogger, string secondVlogger)
        {
            //check if both vloggers exist in dictionary:
            if (!vloggers.ContainsKey(firstVlogger) || !vloggers.ContainsKey(secondVlogger))
            {
                return;
            }
            //check if vlogger tries to follow themselve:
            if (firstVlogger == secondVlogger)
            {
                return;
            }
            //check whether first vlogger is already following second vlogger:
            if (vloggers[secondVlogger]["followers"].Contains(firstVlogger))
            {
                return;
            }
            vloggers[firstVlogger]["following"].Add(secondVlogger);
            vloggers[secondVlogger]["followers"].Add(firstVlogger);
        }

        static void AddToDictionary(string vloggerName)
        {
            if (!vloggers.ContainsKey(vloggerName))
            {
                vloggers.Add(vloggerName, new Dictionary<string, HashSet<string>>());
                vloggers[vloggerName].Add("following", new HashSet<string>());
                vloggers[vloggerName].Add("followers", new HashSet<string>());
            }
        }
    }
}