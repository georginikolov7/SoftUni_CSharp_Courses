namespace P01_CountSameValuesInArr
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<float,int> numberOccurrances = new Dictionary<float,int>();
            float[] input = Console.ReadLine()
                .Split()
                .Select(float.Parse)
                .ToArray();
            foreach(float num in input)
            {
                if (numberOccurrances.ContainsKey(num))
                {
                    numberOccurrances[num]++;
                }
                else
                {
                    numberOccurrances.Add(num, 1);
                }
            }
            foreach(var kvp in numberOccurrances)
            {
                Console.WriteLine($"{kvp.Key} - {kvp.Value} times");
            }
        }
    }
}