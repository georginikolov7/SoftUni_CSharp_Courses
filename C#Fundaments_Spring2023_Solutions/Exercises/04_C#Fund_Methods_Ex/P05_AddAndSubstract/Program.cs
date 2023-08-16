namespace P05_AddAndSubstract
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num1=int.Parse(Console.ReadLine());
            int num2=int.Parse(Console.ReadLine()); 
            int num3=int.Parse(Console.ReadLine());
           
            int finalResult = SubstractThirdFromFirstResult(AddFirstAndSecond(num1, num2), num3);
            Console.WriteLine(finalResult);
        }

        private static int SubstractThirdFromFirstResult(int firstResult, int num3)
        {
            return firstResult - num3;
        }

        static int AddFirstAndSecond(int num1, int num2)
        {
            return  num1 + num2;
            
        }

        
    }
}