

Action<List<int>> printer = x =>
{
    Console.WriteLine(string.Join(" ",x));
};

Func<string, List<int>, List<int>> executeCommand = (command, nums) =>
{
    List<int> result = new List<int>();
    foreach (int num in nums)
    {
        switch (command)
        {
            case "add":
                result.Add(num + 1);
                break;
            case "multiply":
                result.Add(num *2);
                break;
            case "subtract":
                result.Add(num -1);
                break;
        }
    }
    return result;
};


List<int> nums = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();
string command;
while ((command = Console.ReadLine()) != "end")
{
    if(command == "print")
    {
        printer(nums);
        continue;
    }
    nums=executeCommand(command, nums);
}