

Action<string[]> printer=x =>
{
    foreach (var item in x)
    {
        Console.WriteLine(item);
    }
};
string[] names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
printer(names);