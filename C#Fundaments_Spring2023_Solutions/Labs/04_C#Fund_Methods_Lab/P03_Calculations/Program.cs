string action = Console.ReadLine();
int n1=int.Parse(Console.ReadLine());
int n2=int.Parse(Console.ReadLine());
if (action == "add")
{
    GetSum(n1, n2);
}
else if (action == "multiply")
{
    GetProduct(n1, n2);
}
else if(action== "subtract")
{
    GetDifference(n1, n2);
}
else if (action == "divide")
{
    GetDevision(n1, n2);
}

void GetDevision(int n1, int n2)
{
    Console.WriteLine(n1 / n2);
}

void GetDifference(int n1, int n2)
{
    Console.WriteLine(n1-n2);
}

void GetProduct(int n1, int n2)
{
    Console.WriteLine(n1*n2);
}

void GetSum(int n1, int n2)
{
    Console.WriteLine(n1+n2);
}