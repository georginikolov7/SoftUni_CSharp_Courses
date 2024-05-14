
Action<List<int>> printer = x =>
{
    Console.WriteLine(string.Join(" ", x));
};

Func<List<int>, List<int>> reverse = nums =>
{
    List<int> newNums = new();
    for (int i = nums.Count - 1; i >= 0; i--)
    {
        newNums.Add(nums[i]);
    }
    return newNums;
};

Func<List<int>, Predicate<int>, List<int>> exclude = (numbers, match) =>
{
    List<int> result = new();
    foreach (int num in numbers)
    {
        if (!match(num))
        {
            result.Add(num);
        }
    }
    return result;
};

List<int> ints = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToList();

int divider=int.Parse(Console.ReadLine());
Predicate<int> check = number => number % divider == 0;
ints = exclude(ints, check);
ints = reverse(ints);

printer(ints);