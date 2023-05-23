int numbersCount = int.Parse(Console.ReadLine());
decimal sum = 0;

for (int i = 0; i < numbersCount; i++)
{
    decimal input=decimal.Parse(Console.ReadLine());
    sum += input;
}
Console.WriteLine(sum);

