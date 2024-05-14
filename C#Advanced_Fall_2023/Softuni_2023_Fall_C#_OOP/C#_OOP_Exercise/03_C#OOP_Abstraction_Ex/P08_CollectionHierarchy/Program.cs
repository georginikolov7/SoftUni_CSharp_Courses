

using P08_CollectionHierarchy.Models;

Dictionary<string, List<int>> addedIndices = new()
            {
                { "AddCollection", new List<int>() },
                { "AddRemoveCollection", new List<int>() },
                { "MyList", new List<int>() }
            };

Dictionary<string, List<string>> removedItems = new()
            {
                { "AddRemoveCollection", new List<string>() },
                { "MyList", new List<string>() }
            };
AddCollection addCollection = new AddCollection();
AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
MyList myList = new MyList();
string[] strings = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
foreach (string s in strings)
{
    addedIndices["AddCollection"].Add(addCollection.Add(s));
    addedIndices["AddRemoveCollection"].Add(addRemoveCollection.Add(s));
    addedIndices["MyList"].Add(myList.Add(s));
}
int countToRemove = int.Parse(Console.ReadLine());
for (int i = 0; i < countToRemove; i++)
{
    removedItems["AddRemoveCollection"].Add(addRemoveCollection.Remove());
    removedItems["MyList"].Add(myList.Remove());
}
foreach (List<int> indices in addedIndices.Values)
{
    Console.WriteLine(string.Join(" ", indices));
}
foreach (List<string> words in removedItems.Values)
{
    Console.WriteLine(string.Join(" ", words));
}