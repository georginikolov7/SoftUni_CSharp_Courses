int[] ints = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();
int startIndex = int.Parse(Console.ReadLine());

startIndex %= ints.Length;  //determines how many rotations need to be done if number of rotations is bigger than length of array

int[] rotatedInts = new int[ints.Length];

int rotatedIndex = 0;
for (int i = startIndex; i < ints.Length; i++)
{
    rotatedInts[rotatedIndex] = ints[i];
    rotatedIndex++;
}
for (int i = 0; i < startIndex; i++)
{
    rotatedInts[rotatedIndex] = ints[i];
    
    rotatedIndex++;
}
Console.WriteLine(string.Join(" ", rotatedInts));
