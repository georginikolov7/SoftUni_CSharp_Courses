namespace P05_FashionBoutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ///Read input:
            int[] inputValues = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            Stack<int> clothesValues = new Stack<int>(inputValues);

            int rackCapacity = int.Parse(Console.ReadLine());   //max capacity from console
            int currentRackSum = 0;
            int racksCount = 1;
            while (clothesValues.Count > 0)
            {
                int currentValue = clothesValues.Pop();
                currentRackSum += currentValue;
                if (currentRackSum == rackCapacity && clothesValues.Count > 0)
                {
                    racksCount++;
                    currentRackSum = 0;
                }
                if (currentRackSum > rackCapacity)
                {
                    racksCount++;
                    currentRackSum = currentValue;
                }
            }
            Console.WriteLine(racksCount);
        }
    }
}