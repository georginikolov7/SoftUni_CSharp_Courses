

using P09_ExplicitInterfaces.Models;
using P09_ExplicitInterfaces.Models.Interfaces;
using System.Collections.Specialized;

string input;
while ((input = Console.ReadLine()) != "End")
{
    string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string name = tokens[0];
    string country = tokens[1];
    int age = int.Parse(tokens[2]);
    IPerson person = new Citizen(name, country, age);
    Console.WriteLine(person.GetName());
    IResident resident = new Citizen(name, country, age);
    Console.WriteLine(resident.GetName());
}