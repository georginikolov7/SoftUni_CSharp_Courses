namespace P01_RandomizeWords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split().ToArray();
            Random random = new Random();
            for (int i = 0; i < input.Length; i++)
            {
                int randomIndex=random.Next(0, input.Length);   //range is exclusive
                (input[i], input[randomIndex]) = (input[randomIndex], input[i]);

            }
            foreach(string word in input)
            {
                Console.WriteLine(word);
            }
        }
    }
} 