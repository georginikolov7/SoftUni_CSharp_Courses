

using FootballTeamGenerator;

Dictionary<string, Team> teams = new();
string command;




while ((command = Console.ReadLine()) != "END")
{
    string[] tokens = command.Split(";");
    try
    {
        switch (tokens[0])
        {
            case "Team":
                //create team
                Team team = new(tokens[1]);
                teams.Add(tokens[1], team);
                break;
            case "Add":
                string teamNameToAdd = tokens[1];
                if (!teams.ContainsKey(teamNameToAdd))
                {
                    throw new Exception($"Team {teamNameToAdd} does not exist.");

                }
                string playerName = tokens[2];
                int endurance = int.Parse(tokens[3]);
                int sprint = int.Parse(tokens[4]);
                int dribble = int.Parse(tokens[5]);
                int passing = int.Parse(tokens[6]);
                int shooting = int.Parse((tokens[7]));
                Player playerToAdd = new(playerName, endurance, sprint, dribble, passing, shooting);
                teams[teamNameToAdd].AddPlayer(playerToAdd);
                break;
            case "Remove":
                string teamNameToRemove = tokens[1];
                string playerNameToRemove = tokens[2];
                teams[teamNameToRemove].RemovePlayer(playerNameToRemove);
                break;
            case "Rating":
                string teamToRate = tokens[1];
                if (!teams.ContainsKey(teamToRate))
                {
                    throw new Exception($"Team {teamToRate} does not exist.");

                }
                Console.WriteLine($"{teamToRate} - {teams[teamToRate].Rating}");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);

    }
}

