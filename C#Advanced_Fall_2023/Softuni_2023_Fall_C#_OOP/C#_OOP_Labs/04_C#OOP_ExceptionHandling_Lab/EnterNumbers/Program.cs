
List<int> numbers = new();
while (numbers.Count < 10)
{
    try
    {
        
        
        numbers.Add(ReadNumber(numbers.Count == 0 ? 1 : numbers[numbers.Count - 1], 100));
    }
    catch (ArgumentOutOfRangeException ex)
    {
        Console.WriteLine(ex.ParamName);
    }
    catch (FormatException)
    {
        Console.WriteLine("Invalid Number!");
    }
}
Console.WriteLine(string.Join(", ", numbers));


int ReadNumber(int start, int end)
{
    int num = int.Parse(Console.ReadLine());
    if (num <= start || num >= end)
    {
        throw new ArgumentOutOfRangeException($"Your number is not in range {start} - 100!");
    }
    return num;
}