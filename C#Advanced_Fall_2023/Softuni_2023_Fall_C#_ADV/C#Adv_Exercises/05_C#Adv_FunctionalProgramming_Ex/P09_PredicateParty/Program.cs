
List<string> guests = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();
string input;
while ((input = Console.ReadLine()) != "Party!")
{
    string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string action = tokens[0];
    string filter = tokens[1];
    string value = tokens[2];

    switch (action)
    {
        case "Remove":
            guests.RemoveAll(GetPredicate(filter, value));
            break;
        case "Double":
            guests = DoubleMatchedPeople(guests, GetPredicate(filter, value));
            //List<string> peopleToDouble = guests.FindAll(GetPredicate(filter, value));
            //foreach (string person in peopleToDouble)
            //{
            //    int index = guests.IndexOf(person);
            //    guests.Insert(index, person);

            //}
            break;
    }
}

List<string> DoubleMatchedPeople(List<string> guests, Predicate<string> predicate)
{
    List<string> result = new List<string>();
    foreach (string person in guests)
    {
        result.Add(person);
        if (predicate(person))
        {
            result.Add(person);
        }
    }
    return result;
}
if (guests.Count > 0)
{
    Console.WriteLine(string.Join(", ", guests) + " are going to the party!");
}
else
{
    Console.WriteLine("Nobody is going to the party!");
}


static Predicate<string> GetPredicate(string filter, string value)
{
    switch (filter)
    {
        case "StartsWith":
            return p => p.StartsWith(value);
        case "EndsWith":
            return p => p.EndsWith(value);
        case "Length":
            return p => p.Length == int.Parse(value);
        default:
            return default;
    }

}