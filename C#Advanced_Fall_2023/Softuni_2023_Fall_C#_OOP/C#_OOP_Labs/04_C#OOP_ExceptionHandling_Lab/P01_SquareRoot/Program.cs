﻿

int n = int.Parse(Console.ReadLine());
try
{
    if (n < 0)
    {
        throw new ArgumentException("Invalid number.");
    }
    Console.WriteLine(Math.Sqrt(n));
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    Console.WriteLine("Goodbye.");
}
