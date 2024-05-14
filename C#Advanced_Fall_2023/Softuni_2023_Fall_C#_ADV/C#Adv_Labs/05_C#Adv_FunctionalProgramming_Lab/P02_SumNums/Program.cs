Func<string, int> parseInt = x => int.Parse(x);
List<int> nums = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(parseInt)
    .ToList();
Console.WriteLine(nums.Count);
Console.WriteLine(nums.Sum());

