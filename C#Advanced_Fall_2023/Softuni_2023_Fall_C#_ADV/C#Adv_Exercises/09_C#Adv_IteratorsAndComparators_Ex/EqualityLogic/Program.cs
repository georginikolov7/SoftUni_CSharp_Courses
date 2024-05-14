

using EqualityLogic;

PersonComparer personComparer = new PersonComparer();
HashSet<Person> hashSet = new(personComparer);
SortedSet<Person> sortedSet = new();

int count = int.Parse(Console.ReadLine());
for (int i = 0; i < count; i++)
{
    string[] personTokens = Console.ReadLine()
        .Split(" ", StringSplitOptions.RemoveEmptyEntries);

    hashSet.Add(new Person { Name = personTokens[0], Age = int.Parse(personTokens[1]) });
    sortedSet.Add(new Person { Name = personTokens[0], Age = int.Parse(personTokens[1]) });

}
Console.WriteLine(hashSet.Count);
Console.WriteLine(sortedSet.Count);