
Func<List<string>, int, Func<string, int, bool>, string> FindFirstNameThatMatchesCondition = (names, sumThreshold, match) =>
{
    return names.FirstOrDefault(name => match(name, sumThreshold));
};
Func<string, int, bool> match = (name, sumThreshold) =>
{
    int sum = 0;
    foreach (char ch in name)
    {
        sum += ch;
    }
    return sum >= sumThreshold;
};
int sumThreshold = int.Parse(Console.ReadLine());
List<string> names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();
string result = FindFirstNameThatMatchesCondition(names, sumThreshold, match);
Console.WriteLine(result);