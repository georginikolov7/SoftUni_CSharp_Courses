int fieldSize = int.Parse(Console.ReadLine());
int[] field = new int[fieldSize];
int[] ladybugIndexes = Console.ReadLine()
    .Split(" ")
    .Select(int.Parse)
    .ToArray();

for (int i = 0; i < ladybugIndexes.Length; i++)     //second input line -> fills initial field
{
    int bugIndex = ladybugIndexes[i];
    if (bugIndex >= 0 && bugIndex < fieldSize)
    {
        field[bugIndex] = 1;
    }
}
string command;
while ((command = Console.ReadLine()) != "end")
{
    string[] input = command.Split(" ");
    int ladyBugIndex = int.Parse(input[0]);
    string direction = input[1];
    int flyLength = int.Parse(input[2]);

    if (ladyBugIndex < 0 || ladyBugIndex >= fieldSize || field[ladyBugIndex] == 0)
    {
        continue;
    }
    field[ladyBugIndex] = 0;

    //determine flight direction and landIndex
    if (direction == "left")
    {
        flyLength = -flyLength;
    }
    int landIndex = ladyBugIndex + flyLength;

    //flight process
    
    
    while (true)
    {
        if (landIndex < 0 || landIndex >= fieldSize) break;
        else if (field[landIndex] == 1)
        {
            landIndex += flyLength;
            continue;
        }
        else
        {
            field[landIndex] = 1;
            break;
        }
    }
}
foreach (int index in field)
{
    Console.Write(index + " ");
}