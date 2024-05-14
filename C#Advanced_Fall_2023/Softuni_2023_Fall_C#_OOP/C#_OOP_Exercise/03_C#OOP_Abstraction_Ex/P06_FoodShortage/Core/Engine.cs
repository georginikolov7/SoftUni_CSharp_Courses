using P04_BorderControl.Models;
using P04_BorderControl.Models.Interfaces;
using P05_Birthday.Models;
using P05_Birthday.Models.Interfaces;
using P06_FoodShortage.Models;
using P06_FoodShortage.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P04_BorderControl.Core
{
    public class Engine
    {
        public void Run()
        {
            List<IBuyer> buyers = new List<IBuyer>();
            int countOfPeople = int.Parse(Console.ReadLine());
            IBuyer buyer = null;
            for (int i = 0; i < countOfPeople; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                if (tokens.Length == 4)
                {
                    buyer = new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2], tokens[3]);
                }
                else
                {
                    buyer = new Rebel(tokens[0], int.Parse(tokens[1]), tokens[2]);

                }
                buyers.Add(buyer);
            }

            int totalPurchasedFood = CalculatePurchasedFood(buyers);
            Console.WriteLine(totalPurchasedFood);
        }

        private int CalculatePurchasedFood(List<IBuyer> buyers)
        {
            int totalFood = 0;
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                if (buyers.Exists(b => b.Name == input))
                {
                    totalFood += buyers[buyers.IndexOf(buyers.FirstOrDefault(b => b.Name == input))].BuyFood();
                }
            }
            return totalFood;
        }
    }
}
