using System.Net.Http.Headers;

int n = int.Parse(Console.ReadLine());
PrintTriangle(n);

void PrintTriangle(int n)
{
    for (int i = 1; i <= n; i++)
    {
        PrintLine(i);

    }
    for (int i = n - 1; i >= 1; i--)
    {
        PrintLine(i);
    }
}

void PrintLine(int currentEndNumber)
{
    for (int i = 1; i <= currentEndNumber; i++)
    {
        Console.Write($"{i} ");
    }
    Console.WriteLine();
}