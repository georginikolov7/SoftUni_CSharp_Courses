int countOfNums = int.Parse(Console.ReadLine());
for (int i = 1; i <= countOfNums; i++)
{
    bool isSpecial = false;
    int currentNumber = i;  
    
    int sum = 0;
    while (currentNumber != 0)
    {
        sum += currentNumber % 10;
        currentNumber = currentNumber / 10;
    }
    isSpecial = (sum == 5) || (sum == 7) || (sum == 11);
    Console.WriteLine("{0} -> {1}", i, isSpecial);
    
    
}