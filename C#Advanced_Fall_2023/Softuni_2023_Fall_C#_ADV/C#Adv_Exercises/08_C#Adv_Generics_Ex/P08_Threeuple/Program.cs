

//{first name} {last name} {address} {town}:
using System.Text.RegularExpressions;
using P08_Threeuple;
string pattern = @"(?<name>\w+ \w+) (?<adress>[\w+]+) (?<town>[\w+ ]+)";
Match nameAdressTown = Regex.Match(Console.ReadLine(), pattern);
string name = nameAdressTown.Groups["name"].Value;
string adress = nameAdressTown.Groups["adress"].Value;
string town = nameAdressTown.Groups["town"].Value;
Threeuple<string, string, string> input1 = new(name, adress, town);
Console.WriteLine(input1.ToString());

//{name} {liters of beer} {drunk or not}
string[] tokens = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

bool isDrunk = tokens[2] == "drunk";
Threeuple<string, int, bool> input2 = new(tokens[0], int.Parse(tokens[1]), isDrunk);
Console.WriteLine(input2.ToString());

//{name} {account balance} {bank name}
string[] tokens1 = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
Threeuple<string, double, string> input3 = new(tokens1[0], double.Parse(tokens1[1]), tokens1[2]);
Console.WriteLine(input3.ToString());
