

using P03_GenericSwapMethod;
List<Box<int>> list = new();
int count = int.Parse(Console.ReadLine());
for (int i = 0; i < count; i++)
{
    list.Add(new Box<int>(int.Parse(Console.ReadLine())));
}

int[] indexesToSwap = Console.ReadLine()
    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
    .Select(int.Parse)
    .ToArray();
SwapBox(indexesToSwap[0], indexesToSwap[1]);

foreach (var box in list)
{
    Console.WriteLine(box.ToString());
}

void SwapBox(int index1, int index2)
{
    (list[index1], list[index2]) = (list[index2], list[index1]);
}
