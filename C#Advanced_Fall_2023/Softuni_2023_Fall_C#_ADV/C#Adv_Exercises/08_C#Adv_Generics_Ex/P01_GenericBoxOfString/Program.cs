

using P01_GenericBoxOfString;

int n = int.Parse(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    Box<int> box = new Box<int>(int.Parse(Console.ReadLine()));
    Console.WriteLine(box.ToString());
}