using System;
namespace P08_BeerKeg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int kegCount = int.Parse(Console.ReadLine());
            string biggestKeg=string.Empty;
            float biggestVol = 0;
            for (int i = 0; i < kegCount; i++)
            {
                string modelOfKeg = Console.ReadLine();
                float radius=float.Parse(Console.ReadLine());
                int height=int.Parse(Console.ReadLine());
                float vol = (float)(Math.PI * Math.Pow(radius, 2) * height);
                if (vol > biggestVol)
                {
                    biggestVol = vol;
                    biggestKeg = modelOfKeg;
                }
            }
            Console.WriteLine(biggestKeg);
        }
    }
}