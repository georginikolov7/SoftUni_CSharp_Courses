
using System.Text.RegularExpressions;

namespace P10_ForceBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, SortedSet<string>> sidesUsers = new();
            string input;
            string pattern = @"(?<token1>.+) +(?<identifier>\||->) +(?<token2>.+)";
            while ((input = Console.ReadLine()) != "Lumpawaroo")
            {

                Match command = Regex.Match(input, pattern);
                string identifier = command.Groups["identifier"].Value;
                string token1 = command.Groups["token1"].Value;
                string token2 = command.Groups["token2"].Value;
                if (identifier == "|")
                {
                    //{forceSide} | {forceUser}
                    AddUserToSide(token1, token2, sidesUsers);

                }
                else if (identifier == "->")
                {
                    //{forceUser} -> {forceSide}
                    SwitchSide(token1, token2, sidesUsers);
                }
            }

            //Print:
            foreach (var kvp in sidesUsers.OrderByDescending(x => x.Value.Count())
                .ThenBy(x => x.Key))
            {
                if (kvp.Value.Count() == 0)
                {
                    continue;
                }
                Console.WriteLine($"Side: {kvp.Key}, Members: {kvp.Value.Count}");
                foreach (string user in kvp.Value)
                {
                    Console.WriteLine($"! {user}");
                }
            }
        }

        static void SwitchSide(string forceUser, string forceSide, Dictionary<string, SortedSet<string>> sidesUsers)
        {
            foreach (var kvp in sidesUsers)
            {
                if (kvp.Value.Contains(forceUser))
                {
                    kvp.Value.Remove(forceUser);
                    break;
                }
            }
            AddUserToSide(forceSide, forceUser, sidesUsers);
            Console.WriteLine($"{forceUser} joins the {forceSide} side!");
        }

        static void AddUserToSide(string forceSide, string forceUser, Dictionary<string, SortedSet<string>> sidesUsers)
        {
            if (sidesUsers.Values.Any(x => x.Contains(forceUser)))
            {
                return;
            }
            if (!sidesUsers.ContainsKey(forceSide))
            {
                sidesUsers[forceSide] = new SortedSet<string>();
            }
            sidesUsers[forceSide].Add(forceUser);
        }
    }
}