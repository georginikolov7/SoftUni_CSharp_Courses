

using P05_GenericCountMethod;

List<Box<double>> boxes = new();
int n = int.Parse(Console.ReadLine());
for (int i = 0; i < n; i++)
{
    boxes.Add(new Box<double>(double.Parse(Console.ReadLine())));
}
double valueToCompare = double.Parse(Console.ReadLine());
int count = 0;
foreach (Box<double> box in boxes)
{
    if (valueToCompare.CompareTo(box.Value) < 0)
    {
        count++;
    }
}
Console.WriteLine(count);