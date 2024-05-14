namespace P03_SimpleCalc
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split();
            Array.Reverse(input);
            Stack<string> stack = new Stack<string>();
            foreach(var item in input)
            {
                stack.Push(item);
            }
            int result=int.Parse(stack.Pop());
            while (stack.Count > 0)
            {
                char operation= char.Parse(stack.Pop());
                int num=int.Parse(stack.Pop());
                if(operation == '+')
                {
                    result += num;
                }
                else if (operation == '-')
                {
                    result -= num;
                }
            }
            Console.WriteLine(result);
        }
    }
}