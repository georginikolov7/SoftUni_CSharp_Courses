using P01_ClassBoxData;
using System.Security.Cryptography;

public class StartUp
{
    static void Main()
    {
        double length, width, height;
        length = double.Parse(Console.ReadLine());
        width = double.Parse(Console.ReadLine());
        height = double.Parse(Console.ReadLine());
        try
        {
            Box box = new(length, width, height);
            Console.WriteLine(box); 
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}