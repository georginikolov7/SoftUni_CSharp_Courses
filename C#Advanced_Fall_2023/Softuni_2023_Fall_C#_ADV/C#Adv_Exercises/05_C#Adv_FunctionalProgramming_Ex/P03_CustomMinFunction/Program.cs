Func<HashSet<int>, int> min = nums =>
{
    int min = int.MaxValue;
    foreach (int i in nums)
    {
        if (i < min)
        {
            min = i;
        }
    }
    return min;
};

HashSet<int> nums = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(x => int.Parse(x))
    .ToHashSet();
Console.WriteLine(min(nums));


