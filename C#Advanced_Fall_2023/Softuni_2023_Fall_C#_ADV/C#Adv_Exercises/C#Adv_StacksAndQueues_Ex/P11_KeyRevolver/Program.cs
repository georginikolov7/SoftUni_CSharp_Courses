

namespace P11_KeyRevolver
{
    internal class Program
    {
        static Stack<int> bullets = new Stack<int>();
        static Queue<int> locks = new Queue<int>();
        static void Main(string[] args)
        {

            //Read inputs:
            int pricePerBullet = int.Parse(Console.ReadLine());
            int sizeOfGunBarrel = int.Parse(Console.ReadLine());
            int[] bulletValues = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            foreach (int bullet in bulletValues)
            {
                bullets.Push(bullet);
            }
            int[] lockValues = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            foreach (int lockVal in lockValues)
            {
                locks.Enqueue(lockVal);
            }
            int intelligenceValue = int.Parse(Console.ReadLine());


            //start shooting at locks:
            bool flag = false;  //checks whether operation was failed
            int bulletsShotCount = 0;
            while (locks.Count > 0)
            {
                int currentBullet = bullets.Pop();
                bulletsShotCount++;

                if (locks.Peek() >= currentBullet)              //can be destroyed
                {
                    Console.WriteLine("Bang!");
                    locks.Dequeue();
                }
                else
                {
                    Console.WriteLine("Ping!");
                }


                if (bullets.Count == 0 && locks.Count > 0)
                {
                    flag = true;
                    break;
                }
                if (bulletsShotCount % sizeOfGunBarrel == 0 && bullets.Count>0)    //need to reload:
                {
                    Console.WriteLine("Reloading!");
                }
            }

            //Print outcome:
            int totalPriceOfBullets = bulletsShotCount * pricePerBullet;
            if (flag)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
            }
            else
            {
                Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligenceValue - totalPriceOfBullets}");
            }
        }


    }
}