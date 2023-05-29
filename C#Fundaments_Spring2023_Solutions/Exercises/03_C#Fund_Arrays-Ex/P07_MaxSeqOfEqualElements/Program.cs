int[] arr = Console.ReadLine()
    .Split()
    .Select(int.Parse)
    .ToArray();
int biggestNumber=0;
int biggestSequenceLength=1;
for (int i = 0; i < arr.Length; i++)
{
    int currentSequenceLength = 1;
    for (int j = i+1; j < arr.Length; j++)
    {
        if (arr[j] != arr[i])
        {
            break;
        }
        currentSequenceLength++;
    }
    if (currentSequenceLength > biggestSequenceLength)
    {
        biggestSequenceLength = currentSequenceLength;
        biggestNumber = arr[i];
    }
}
for (int i = 0; i < biggestSequenceLength; i++)
{
    Console.Write(biggestNumber+" ");
}


