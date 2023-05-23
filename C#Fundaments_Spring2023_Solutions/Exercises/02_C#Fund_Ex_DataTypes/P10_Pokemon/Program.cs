using System;
namespace P10_Pokemon
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int pokePower=int.Parse(Console.ReadLine());//N
            int originalPokePower = pokePower;
            int pokeDistance=int.Parse(Console.ReadLine());//M
            int exhaustionFactor=int.Parse(Console.ReadLine());//Y
            int targetCount = 0;
            while (pokePower>=pokeDistance)
            {
                pokePower-=pokeDistance;
                targetCount++;
                if (pokePower == 0.50 * originalPokePower)
                {
                    if (exhaustionFactor != 0)
                    {
                        pokePower /= exhaustionFactor;
                    }
                }
            }
            Console.WriteLine(pokePower);
            Console.WriteLine(targetCount);
        }
    }
}