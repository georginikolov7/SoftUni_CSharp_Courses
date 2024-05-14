using System.IO.Pipes;

namespace P03_MaxAndMinElement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            int numOfQueries=int.Parse(Console.ReadLine());
            for (int i = 0; i < numOfQueries; i++)
            {
                int[] query=Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
                switch (query[0])
                {
                    case 1:
                        stack.Push(query[1]); 
                        break;
                    case 2:
                        stack.Pop();
                        break;
                    case 3:
                        if (stack.Count > 0)
                        {
                            Console.WriteLine(stack.Max());
                        }
                        break;
                    case 4:
                        if (stack.Count > 0)
                        {
                            Console.WriteLine(stack.Min());
                        }
                        break;
                   

                }
            }
            Console.WriteLine(string.Join(", ", stack));
        }
    }
}