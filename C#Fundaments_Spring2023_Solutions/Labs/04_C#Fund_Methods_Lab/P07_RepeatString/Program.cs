string input = Console.ReadLine();
int numberOfReps = int.Parse(Console.ReadLine());
Console.WriteLine(GetRepeatedString(input,numberOfReps));
static string GetRepeatedString(string input, int numberOfReps)
{
	string repeatedString=string.Empty;
	for (int i = 0; i < numberOfReps; i++)
	{
		repeatedString += input;
	}
	return repeatedString;
}