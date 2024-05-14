
List<string> people = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();

Dictionary<string, Predicate<string>> filters = new();
string command;

while ((command = Console.ReadLine()) != "Print")
{
    //"{command;filter type;filter parameter}"
    string[] tokens = command.Split(";");
    string action = tokens[0];
    string filter = tokens[1];
    string param = tokens[2];
    string currentKey = filter + param;
    switch (action)
    {
        case "Add filter":
            if (!filters.ContainsKey(currentKey))
            {
                filters.Add(currentKey, GenerateFilter(filter, param));
            }
            break;
        case "Remove filter":
            filters.Remove(currentKey);
            break;
    }
}

List<string> approvedPeople = new();
foreach (string person in people)
{
    bool isApproved = true;
    foreach (var filter in filters.Values)
    {
        if (filter(person))
        {
            isApproved = false;
            break;
        }

    }
    if (isApproved)
    {
        approvedPeople.Add(person);
    }
}
Console.WriteLine(string.Join(" ", approvedPeople));


Predicate<string> GenerateFilter(string filter, string param)
{
    switch (filter)
    {
        case "Starts with":
            return p => p.StartsWith(param);
        case "Ends with":
            return p => p.EndsWith(param);
        case "Length":
            return p => p.Length == int.Parse(param);
        case "Contains":
            return p => p.Contains(param);
        default:
            return default;
    }
}