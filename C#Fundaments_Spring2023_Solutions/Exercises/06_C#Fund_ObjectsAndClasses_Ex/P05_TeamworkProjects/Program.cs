

namespace P05_TeamworkProjects
{
    public class Team
    {
        public Team(string creator, string name)
        {
            Members = new List<string>();
            Creator = creator;
            Name = name;
        }
        public string Creator { get; set; }
        public string Name { get; set; }
        public List<string> Members { get; set; }

        public override string ToString()
        {
            string result=string.Empty;
            result += Name+ "\n";
            result += $"- {Creator}\n";
            foreach (string memberName in Members.OrderBy(x=>x))
            {
                result +=$"-- {memberName}\n";
            }
            return result.Trim();
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Create teams:
            int countOfTeams = int.Parse(Console.ReadLine());
            List<Team> teams = new List<Team>();
            for (int i = 0; i < countOfTeams; i++)
            {
                string[] input = Console.ReadLine()
                    .Split('-');
                AddTeam(input, teams);
            }

            //Fill team members:
            string command;
            while ((command = Console.ReadLine()) != "end of assignment")
            {
                string[] arguments = command.Split("->");
                string memberName = arguments[0];
                string teamToJoin = arguments[1];
                AddMemberToTeam(teams, memberName, teamToJoin);
            }

            //Print:
            List<Team> emptyTeams = new List<Team>();
            for (int i = 0; i < teams.Count; i++)
            {
                if (teams[i].Members.Count == 0)
                {
                    emptyTeams.Add(teams[i]);
                    teams.RemoveAt(i);
                    i--;
                }
            }
            foreach (Team team in teams.OrderByDescending(x => x.Members.Count).ThenBy(x => x.Name))
            {
                Console.WriteLine(team.ToString());
            }

            Console.WriteLine("Teams to disband:");
            foreach (Team team in emptyTeams.OrderBy(x=>x.Name))
            {
                Console.WriteLine(team.Name);
            }

        }

        static void AddTeam(string[] input, List<Team> teams)
        {
            Team currentTeam = new Team(input[0], input[1]);
            foreach (Team team in teams)
            {
                if (currentTeam.Name == team.Name)
                {
                    Console.WriteLine($"Team {team.Name} was already created!");
                    return;
                }
                else if (currentTeam.Creator == team.Creator)
                {
                    Console.WriteLine($"{team.Creator} cannot create another team!");
                    return;
                }
            }

            teams.Add(currentTeam);
            Console.WriteLine($"Team {currentTeam.Name} has been created by {currentTeam.Creator}!");
        }
        static void AddMemberToTeam(List<Team> teams, string memberName, string teamToJoin)
        {

            int indexOfSelectedTeam = teams.FindIndex(x => x.Name == teamToJoin);
            if (indexOfSelectedTeam == -1)
            {
                Console.WriteLine($"Team {teamToJoin} does not exist!");
            }
            else if (teams.Exists(x => x.Members.Contains(memberName)) || teams.Exists(x => x.Creator == memberName))
            {
                Console.WriteLine($"Member {memberName} cannot join team {teamToJoin}!");
            }
            else
            {
                teams[indexOfSelectedTeam].Members.Add(memberName);
            }
        }

    }
}