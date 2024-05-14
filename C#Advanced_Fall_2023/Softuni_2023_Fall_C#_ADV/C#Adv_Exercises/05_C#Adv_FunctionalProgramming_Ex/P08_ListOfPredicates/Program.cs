
Func<int, List<int>> rangeGenerator = end =>
    {
        List<int> list = new List<int>();
        for (int i = 1; i <= end; i++)
        {
            list.Add(i);
        }
        return list;
    };
Func<List<int>, Predicate<int>, List<int>> findAllNumbersDivisibleByDividers = (range, isDevisibleByAll) =>
{
    List<int> result = new List<int>();
    foreach (int num in range)
    {
        if (isDevisibleByAll(num))
        {
            result.Add(num);
        }
    }
    return result;
};
//generate the range of ints:
int endOfRange = int.Parse(Console.ReadLine());
List<int> range = rangeGenerator(endOfRange);

//Read dividers:
HashSet<int> dividers = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToHashSet();

Predicate<int> isDivisibleByAll = num =>
{
    foreach (int divider in dividers)
    {
        if (num % divider != 0)
        {
            return false;
        }
    }
    return true;
};

List<int> result = findAllNumbersDivisibleByDividers(range, isDivisibleByAll);
Console.WriteLine(string.Join(" ", result));