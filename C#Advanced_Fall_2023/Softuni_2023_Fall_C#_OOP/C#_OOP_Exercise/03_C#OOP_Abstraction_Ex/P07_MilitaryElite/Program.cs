

using P07_MilitaryElite.Enums;
using P07_MilitaryElite.Models;
using P07_MilitaryElite.Models.Interfaces;

internal class Program
{
    static Dictionary<int, ISoldier> soldiers = new();
    private static void Main(string[] args)
    {
        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            
            string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string soldierType = tokens[0];
            int id = int.Parse(tokens[1]);
            string firstName = tokens[2];
            string lastName = tokens[3];
            ISoldier soldier = null;
            try
            {
                switch (tokens[0])
                {
                    case "Private":
                        soldier = GetPrivate(id, firstName, lastName, decimal.Parse(tokens[4]));

                        break;
                    case "LieutenantGeneral":
                        soldier = GetLieutenantGeneral(id, firstName, lastName, tokens);

                        break;
                    case "Engineer":
                        soldier = GetEngineer(id, firstName, lastName, tokens);

                        break;
                    case "Commando":
                        soldier = GetCommando(id, firstName, lastName, tokens);

                        break;
                    case "Spy":
                        soldier = GetSpy(id, firstName, lastName, int.Parse(tokens[4]));
                        break;
                }
                soldiers.Add(id, soldier);
            }
            catch { }
        }
        foreach (var soldier in soldiers.Values)
        {
            Console.WriteLine(soldier.ToString());
        }
    }

    private static ISoldier? GetSpy(int id, string firstName, string lastName, int codeNum)
    {
        return new Spy(id, firstName, lastName, codeNum);
    }

    private static ISoldier? GetCommando(int id, string firstName, string lastName, string[] tokens)
    {
        decimal salary = decimal.Parse(tokens[4]);
        bool isValidCorps = Enum.TryParse<Corps>(tokens[5], out Corps corps);
        if (!isValidCorps)
        {
            throw new Exception();
        }
        List<IMission> missions = new List<IMission>();
        for (int i = 6; i < tokens.Length - 1; i += 2)
        {
            string missionName = tokens[i];
            string missionState = tokens[i + 1];
            bool isValidMissionState = Enum.TryParse<State>(missionState, out State state);
            if (!isValidMissionState)
            {
                continue;
            }
            IMission mission = new Mission(missionName, state);
            missions.Add(mission);
        }
        return new Commando(id, firstName, lastName, salary, corps, missions);
    }

    private static ISoldier? GetEngineer(int id, string firstName, string lastName, string[] tokens)
    {
        decimal salary = decimal.Parse(tokens[4]);
        bool isValidCorps = Enum.TryParse(tokens[5], out Corps corps);
        if (!isValidCorps)
        {
            throw new Exception();
        }

        List<IRepair> repairs = new();
        for (int i = 6; i < tokens.Length - 1; i += 2)
        {
            IRepair repair = new Repair(tokens[i], int.Parse(tokens[i + 1]));
            repairs.Add(repair);
        }
        return new Engineer(id, firstName, lastName, salary, corps, repairs);
    }

    private static ISoldier? GetLieutenantGeneral(int id, string firstName, string lastName, string[] tokens)
    {
        decimal salary = decimal.Parse(tokens[4]);
        List<IPrivate> privates = new();
        for (int i = 5; i < tokens.Length; i++)
        {
            IPrivate @private = (IPrivate)soldiers[int.Parse(tokens[i])];
            privates.Add(@private);
        }
        return new LieutenantGeneral(id, firstName, lastName, salary, privates);
    }

    private static ISoldier? GetPrivate(int id, string firstName, string lastName, decimal salary) =>
        new Private(id, firstName, lastName, salary);
}