

using P01_Stealer;
using System.Reflection;

namespace Stealer
{
    public class StartUp
    {
        static void Main()
        {
            Spy spy = new();
            Console.WriteLine(spy.CollectGettersAndSetters("Stealer.Hacker"));
        }
    }
}