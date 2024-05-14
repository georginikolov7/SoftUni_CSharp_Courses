using Froggy;

int[] input=Console.ReadLine()
    .Split(", ",StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();

Lake lake = new Lake(input);

Console.WriteLine(string.Join(", ",lake));