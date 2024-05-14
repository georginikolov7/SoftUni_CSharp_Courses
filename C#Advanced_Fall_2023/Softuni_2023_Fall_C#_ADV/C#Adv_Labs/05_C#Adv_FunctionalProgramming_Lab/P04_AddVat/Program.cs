List<double> prices = Console.ReadLine()
    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
    .Select(double.Parse)
    .Select(x => x = 1.20 * x)
    .ToList();
foreach (var pr in prices)
{
    Console.WriteLine($"{pr:f2}");
}