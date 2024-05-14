using P05_DateModifier;
public class StartUp
{
    static void Main()
    {
        string str1=Console.ReadLine();
        string str2=Console.ReadLine();
        
        Console.WriteLine(DateModifier.GetDifferenceInDays(str1, str2));
    }
}