namespace P03_FloatingEquality
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double firstNum=double.Parse(Console.ReadLine());
            double secondNum=double.Parse(Console.ReadLine());
            double eps = 0.000001;
            bool areEqual = false;
            if (Math.Abs(firstNum-secondNum)<eps)
            {
                areEqual = true;
            }
            Console.WriteLine(areEqual);
        }
    }
}