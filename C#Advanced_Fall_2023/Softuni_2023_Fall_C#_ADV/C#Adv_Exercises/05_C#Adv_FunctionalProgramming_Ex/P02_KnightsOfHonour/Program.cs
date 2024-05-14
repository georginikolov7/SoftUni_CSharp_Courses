
using System.Threading.Channels;

Action<List<string>,string> printWithSir = (names,title) =>
    names.ForEach(x => Console.WriteLine(title + x));

List<string> names = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .ToList();
printWithSir(names,"Sir");

