double baseNum =double.Parse(Console.ReadLine());
int power=int.Parse(Console.ReadLine());
Console.WriteLine(RaiseADoubleToAPower(baseNum,power));

static double RaiseADoubleToAPower(double baseNum, int power)
{
    double result=1;
    for (int i = 0; i < power; i++) 
    {
        result *= baseNum;
    }
    return result;
}