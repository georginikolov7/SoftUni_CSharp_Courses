
namespace P05_MultiplyBigNum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string bigNum = Console.ReadLine();

            int multiplyNum = int.Parse(Console.ReadLine());
            if (bigNum == "0" || multiplyNum == 0)
            {
                Console.WriteLine(0);
                return;
            }

            List<int> result = new List<int>();
            int carry = 0;
            for (int i = bigNum.Length - 1; i >= 0; i--)
            {
                int digit = int.Parse(bigNum[i].ToString());
                result.Insert(0,(digit * multiplyNum + carry) % 10);
                carry = (digit * multiplyNum + carry) / 10;
            }

            if (carry != 0)
            {
                result.Insert(0,carry);
            }
            //result.Reverse();
            foreach (int n in result)
            {
                Console.Write(n);
            }
        }
    }
}