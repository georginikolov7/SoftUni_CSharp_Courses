namespace P04_MatchingBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string expression = Console.ReadLine();
            Stack<int> openingIndexes= new Stack<int>();
            for(int i=0;i<expression.Length;i++)
            {
                if (expression[i] == '(')
                {
                    openingIndexes.Push(i);
                }
                else if (expression[i] == ')')
                {
                    int startIndex= openingIndexes.Pop();
                    int length= i -startIndex+1;
                    Console.WriteLine(expression.Substring(startIndex,length));
                }
            }
        }
    }
}