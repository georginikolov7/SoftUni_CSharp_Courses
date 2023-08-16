namespace P11_MathOperations
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            string @operator = Console.ReadLine();
            int b = int.Parse(Console.ReadLine());
            double result = Calculate(a, b, @operator);
            Console.WriteLine(result);
        }
        static double Calculate(int a, int b, string @operator)
        {
            switch (@operator)
            {
                case ("+"):
                    return a + b;
                    break;
                case ("-"):
                    return a - b;
                    break;
                case ("*"):
                    return a * b;
                    break;
                case ("/"):
                    return (double)a / b;
                    break;
                default: return 0; break;

            }
        }
    }
}