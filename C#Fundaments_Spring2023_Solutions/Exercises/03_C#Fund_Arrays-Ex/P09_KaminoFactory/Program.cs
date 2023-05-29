int sequencesLength = int.Parse(Console.ReadLine());
int[] bestSequence = new int[sequencesLength];
int bestCountOf1 = 0;
int bestStartingIndex = int.MaxValue;

int sequenceIndex = 1;      //numbers the sequences
int counter = 0;
string input;
while ((input = Console.ReadLine()) != "Clone them!")
{
    counter++;

    int[] currentSequence = input
        .Split("!".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
        .Select(int.Parse)
        .ToArray();
    int currentCountOf1 = 0;
    int currentStartingIndex = 0;
    getCountOf1(currentSequence, ref currentStartingIndex, ref currentCountOf1);
    if ((currentCountOf1 > bestCountOf1)
        || (currentCountOf1 == bestCountOf1 && currentStartingIndex < bestStartingIndex)
            || (currentCountOf1 == bestCountOf1 && currentStartingIndex == bestStartingIndex && currentSequence.Sum() > bestSequence.Sum())) 
    { 
        bestStartingIndex = currentStartingIndex;
        bestSequence = currentSequence;
        bestCountOf1 = currentCountOf1;
        sequenceIndex = counter;
    }
    
}
Console.WriteLine($"Best DNA sample {sequenceIndex} with sum: {bestSequence.Sum()}.");
Console.WriteLine(string.Join(" ", bestSequence));
//0!1!1!1!1!0

void getCountOf1(int[] currentSequence, ref int currentStartingIndex, ref int currentCountOf1)
{

    for (int i = 0; i < currentSequence.Length; i++)
    {
        int tempCount = 0;
        if (currentSequence[i] == 1)
        {
            int tempIndex = i;

            for (int j = i ; j < currentSequence.Length; j++)
            {
                if (currentSequence[j] == 1)
                {
                    tempCount++;
                    i++;
                    if (tempCount > currentCountOf1)
                    {
                        currentCountOf1 = tempCount;
                        currentStartingIndex = tempIndex;
                    }
                }
                else
                {
                    tempCount = 0;
                    break;
                }

            }
        }
    }
}
