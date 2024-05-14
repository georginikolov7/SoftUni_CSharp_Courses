

namespace Shapes
{
    public class StartUp
    {
        static void Main()
        {
            Circle circle = new Circle(5);
            Console.WriteLine(circle.CalculateArea());
            Console.WriteLine(circle.Draw());
        }
    }
}