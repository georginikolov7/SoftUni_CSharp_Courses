namespace P01_ReverseString
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                char[] arr = input.ToCharArray();
                Array.Reverse(arr);
                Console.WriteLine($"{input} = {new string(arr)}");
            }
        }
    }
}