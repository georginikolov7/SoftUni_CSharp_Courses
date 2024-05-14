

string[] elements = Console.ReadLine().Split(" ");
int sumOfIntegers = 0;
foreach (string element in elements)
{
    try
    {
        sumOfIntegers += int.Parse(element);

    }
    catch (FormatException)
    {
        Console.WriteLine($"The element '{element}' is in wrong format!");
    }
    catch (OverflowException)
    {
        Console.WriteLine($"The element '{element}' is out of range!");
    }
    finally
    {
        Console.WriteLine($"Element '{element}' processed - current sum: {sumOfIntegers}");
    }
}
Console.WriteLine($"The total sum of all integers is: {sumOfIntegers}");