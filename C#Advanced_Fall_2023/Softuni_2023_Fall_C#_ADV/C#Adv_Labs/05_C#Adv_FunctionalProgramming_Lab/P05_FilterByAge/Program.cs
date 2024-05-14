
using System.Security.Cryptography.X509Certificates;
using System.Threading.Channels;

List<Person> people = new List<Person>();
int n = int.Parse(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    string[] tokens = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
    string name = tokens[0];
    int age = int.Parse(tokens[1]);
    people.Add(new Person(name, age));
}
string condition = Console.ReadLine();
int ageThreshold = int.Parse(Console.ReadLine());
string format = Console.ReadLine();
Func<Person, bool> filter = Filter(condition, ageThreshold);

Func<Person, bool> Filter(string condition, int ageThreshold)
{
    if (condition == "younger")
    {
        return x => x.Age < ageThreshold;
    }
    else
    {
        return x => x.Age >= ageThreshold;
    }

}

Action<Person> printer = PrinterGenerator(format);
people = people.Where(st => filter(st)).ToList();
foreach (Person person in people)
{
    printer(person);
}

Action<Person> PrinterGenerator(string format)
{
    if (format == "name")
    {
        return s => Console.WriteLine(s.Name);
    }
    else if (format == "age")
    {
        return s => Console.WriteLine(s.Age);
    }
    else
    {
        return s => Console.WriteLine($"{s.Name} - {s.Age}");
    }
}

class Person
{
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }

    public string Name { get; set; }
    public int Age { get; set; }
}
