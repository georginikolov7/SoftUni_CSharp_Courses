namespace P08_BalancedParanthesis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sequence = Console.ReadLine();
            Stack<char> openingBrackets = new Stack<char>();
            bool flag = false;
            for (int i = 0; i < sequence.Length; i++)
            {
                if (sequence[i] == '('
                    || sequence[i] == '{'
                    || sequence[i] == '[')
                {
                    openingBrackets.Push(sequence[i]);
                    continue;
                }
                if(openingBrackets.Count == 0)
                {
                    flag = true;
                    break;
                }
                if (sequence[i] == ')' && openingBrackets.Peek() == '(')
                {
                    openingBrackets.Pop();
                }
                else if (sequence[i] == '}' && openingBrackets.Peek() == '{')
                {
                    openingBrackets.Pop();
                }
                else if (sequence[i] == ']' && openingBrackets.Peek() == '[')
                {
                    openingBrackets.Pop();
                }
                else
                {
                    flag = true;
                    break;
                }

            }
            if (flag)
            {
                Console.WriteLine("NO");
            }
            else
            {
                Console.WriteLine("YES");
            }
        }
    }
}