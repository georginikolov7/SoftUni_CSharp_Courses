using System.IO.Pipes;
using System.Text;

namespace P09_SimpleTectEditor
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<string> states = new Stack<string>();
            int operationsCount = int.Parse(Console.ReadLine());
            for (int i = 0; i < operationsCount; i++)
            {
                string commandTokens = Console.ReadLine();
                int commandCode = int.Parse(commandTokens[0].ToString());
                string commandArgument = new string(commandTokens.Skip(2).ToArray());
                string previousString=string.Empty;
                if(states.Count> 0) 
                {
                    previousString=states.Peek();
                }
                switch (commandCode)
                {
                    case 1:
                        states.Push(previousString + commandArgument);
                        break;
                    case 2:
                        int count = int.Parse(commandArgument);
                        states.Push(previousString.Remove(previousString.Length - count, count));
                        break;
                        case 3:
                        int index=int.Parse(commandArgument);
                        Console.WriteLine(previousString[index-1]);
                        break;
                        case 4:
                        states.Pop();
                        break;
                }

            }

        }
    }
}