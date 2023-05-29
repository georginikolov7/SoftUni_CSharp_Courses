int maxNumber=int.Parse(Console.ReadLine());
for (int i = 1; i <=maxNumber; i++)
{
    int sumOfDigits = 0;
    int currentNum = i;
    while (currentNum != 0)
    {
        sumOfDigits += currentNum % 10;
        currentNum = currentNum / 10;
    }
    bool isSpecial=sumOfDigits==5||sumOfDigits==7||sumOfDigits==11;
    Console.WriteLine($"{i} -> {isSpecial}");
}
