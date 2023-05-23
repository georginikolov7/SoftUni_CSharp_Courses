using System;
namespace P05_BalancedBrackets
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n=int.Parse(Console.ReadLine());
            bool isBalanced = true;
            string previousBracket=")";               
            string input=string.Empty;
           
            for (int i = 0; i < n; i++)
            {
                input = Console.ReadLine();
                if (input=="(" || input==")")
                {
                    if (input==previousBracket)
                    {
                        isBalanced = false;
                        break;
                    }
                    previousBracket = input;
                    
                }
               
            }
            if (input=="(") isBalanced = false;
            
            if(isBalanced==true)
            {
                Console.WriteLine("BALANCED");
            }
            else
            {
                Console.WriteLine("UNBALANCED");
            }
        }
    }
}