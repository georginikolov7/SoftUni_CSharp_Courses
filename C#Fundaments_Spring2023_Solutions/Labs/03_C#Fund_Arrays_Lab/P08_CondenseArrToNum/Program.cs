int[] ints = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();
while (ints.Length > 1)
{
    int[] condensed = new int[ints.Length - 1];
    for (int i = 0; i < ints.Length - 1; i++)
    {
        condensed[i] = ints[i] + ints[i + 1];
    }
    ints = new int[condensed.Length];
    ints = condensed;
}
Console.WriteLine(ints[0]);

