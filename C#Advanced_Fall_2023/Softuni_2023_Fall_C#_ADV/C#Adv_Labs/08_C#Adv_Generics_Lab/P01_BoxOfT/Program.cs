

namespace BoxOfT
{
    public class StartUp
    {
        static void Main()
        {
            Box<int> box = new Box<int>();
            box.Add(1);
            box.Add(2);
            box.Remove();
            Console.WriteLine(box.Remove());
        }
    }


}