

using System.Text.RegularExpressions;
using P07_Tuple;


//The input consists of three lines:
//•	The first one holds a person's name and an address. They are separated by space(s). Your task is to collect them in the tuple and print them on the console. Format of the input:
//{first name} { last name} { address}:
string pattern = @"(?<name>\w+ \w+) (?<adress>[\w ]+)";
Match nameAndAdress = Regex.Match(Console.ReadLine(), pattern);
string name = nameAndAdress.Groups["name"].Value;
string adress = nameAndAdress.Groups["adress"].Value;
CustomTuple<string, string> input1 = new CustomTuple<string, string>(name, adress);
Console.WriteLine(input1.ToString());


//•	The second line holds a name of a person and the amount of beer (int) he can drink. Format:
//{ name} { liters of beer}
string[] tokens1=Console.ReadLine()
    .Split(" ",StringSplitOptions.RemoveEmptyEntries);
CustomTuple<string, int> input2 = new(tokens1[0], int.Parse(tokens1[1]));
Console.WriteLine(input2.ToString());


//•	The last line holds an integer and a double. Format:
//{ integer} { double}
string[] tokens2 = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
CustomTuple<int, double> input3 = new(int.Parse(tokens2[0]), double.Parse(tokens2[1]));
Console.WriteLine(input3.ToString());
