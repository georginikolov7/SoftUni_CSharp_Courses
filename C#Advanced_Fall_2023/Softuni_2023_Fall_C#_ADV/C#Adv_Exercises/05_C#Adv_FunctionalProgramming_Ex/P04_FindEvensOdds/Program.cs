

using System.Security.Cryptography;

Func<int, int, List<int>> generateRange = (start, end) =>
{
    List<int> result = new List<int>();
    for (int i = start; i <= end; i++)
    {
        result.Add(i);
    }
    return result;
};

Func<string, int, bool> meetsCondition = (command, number) =>
{
    if (command == "even")
    {
        return number % 2 == 0;
    }
    else
    {
        return number % 2 != 0;
    }
};

int[] rangeTokens = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

int start = rangeTokens[0];
int end = rangeTokens[1];
string command = Console.ReadLine();
List<int> nums = generateRange(start, end);
foreach (int num in nums)
{
    if (meetsCondition(command, num))
    {
        Console.Write(num + " ");
    }
}