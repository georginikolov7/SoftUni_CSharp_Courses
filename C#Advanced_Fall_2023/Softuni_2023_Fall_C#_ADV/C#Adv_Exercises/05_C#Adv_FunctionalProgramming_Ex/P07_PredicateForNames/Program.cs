
Action<string[], Predicate<string>> print = (names, match) =>
{
    foreach (string name in names)
    {
        if (match(name))
        {
            Console.WriteLine(name);
        }
    }
};

int targetLength = int.Parse(Console.ReadLine());
string[] names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

Predicate<string> matchesLength = current => current.Length <= targetLength;

print(names, matchesLength);