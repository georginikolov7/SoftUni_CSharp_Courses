namespace P12_CupsAndBottles
{
    internal class Program
    {
        static Stack<int> bottles;
        static Queue<int> cups;
        static void Main(string[] args)
        {
            ReadInputs();
            bool flag = false;
            int wastedWater = 0;
            while (cups.Count > 0)
            {
                if (bottles.Count == 0 && cups.Count > 0)
                {
                    flag = true;
                    break;
                }
                int currentCup = cups.Dequeue();
                wastedWater += FillCup(currentCup);

            }
            if (flag)
            {
                Console.WriteLine($"Cups: {string.Join(" ",cups)}");
            }
            else
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }
            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }

        static int FillCup(int currentCup)
        {
            int wastedWater = 0;
            while (currentCup >= 0)
            {
                int currentBottle = bottles.Pop();
                currentCup -= currentBottle;
                if (currentCup <= 0)
                {
                    wastedWater += Math.Abs(currentCup);
                    break;
                }

            }
            return wastedWater;
        }

        static void ReadInputs()
        {
            int[] cupValues = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            cups = new Queue<int>(cupValues);
            int[] bottleValues = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            bottles = new Stack<int>(bottleValues);
        }
    }
}