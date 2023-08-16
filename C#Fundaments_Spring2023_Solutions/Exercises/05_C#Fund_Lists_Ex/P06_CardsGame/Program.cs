using System.Collections.Generic;
using System.Diagnostics;

namespace P06_CardsGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> player1 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            List<int> player2 = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while (player1.Count > 0 && player2.Count > 0)
            {
                int playerOneCard = player1[0];
                int playerTwoCard = player2[0];
                player1.RemoveAt(0);
                player2.RemoveAt(0);
                if (playerOneCard > playerTwoCard)
                {
                    player1.Add(playerTwoCard);
                    player1.Add(playerOneCard);
                }
                else if (playerTwoCard > playerOneCard)
                {
                    player2.Add(playerOneCard);
                    player2.Add(playerTwoCard);
                }
            }
            if (player1.Count > 0)
            {
                Console.WriteLine($"First player wins! Sum: {player1.Sum()}");
            }
            else
            {
                Console.WriteLine($"Second player wins! Sum: {player2.Sum()}");
            }
        }


    }
}