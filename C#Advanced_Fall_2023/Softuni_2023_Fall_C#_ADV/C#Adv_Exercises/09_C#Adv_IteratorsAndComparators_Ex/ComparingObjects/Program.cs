
using ComparingObjects;

string command;
List<Person> people = new List<Person>();
while ((command = Console.ReadLine()) != "END")
{
    string[] tokens = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    people.Add(new Person(tokens[0], int.Parse(tokens[1]), tokens[2]));
}
int positionToCompare = int.Parse(Console.ReadLine());
Person personToCompare = people[positionToCompare - 1];
int mathes = 0;
foreach (Person person in people)
{
    if (personToCompare.CompareTo(person) == 0) mathes++;
}
if (mathes == 1)    //the personToCompare will always be equal to himself and this shouldn't count as a match 
{
    Console.WriteLine("No matches");
}
else
{
    Console.WriteLine($"{mathes} {people.Count - mathes} {people.Count}");

}