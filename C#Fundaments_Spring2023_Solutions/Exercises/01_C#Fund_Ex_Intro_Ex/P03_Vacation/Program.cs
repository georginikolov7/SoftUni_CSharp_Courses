using System;
using System.Collections.Specialized;

namespace P03_Vacation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double totalPrice = 0;
            int countPeople=int.Parse(Console.ReadLine());
            string typeOfGroup=Console.ReadLine();
            string dayOfWeek=Console.ReadLine();
            if(typeOfGroup=="Students")
            {
                switch (dayOfWeek)
                {
                    case "Friday":
                        totalPrice = countPeople * 8.45;
                        break;
                    case "Saturday":
                        totalPrice = countPeople * 9.80;
                        break;
                    case "Sunday":
                        totalPrice = countPeople * 10.46;
                        break;
                }
                if (countPeople >= 30)
                {
                    totalPrice = 0.85 * totalPrice;
                }
            }
            else if (typeOfGroup == "Business")
            {
                if (countPeople >= 100) countPeople -= 10;
                switch (dayOfWeek)
                {
                    case "Friday":
                        totalPrice = countPeople * 10.90;
                        break;
                    case "Saturday":
                        totalPrice = countPeople * 15.60;
                        break;
                    case "Sunday":
                        totalPrice = countPeople * 16;
                        break;
                }
            }
            else if(typeOfGroup == "Regular")
            {
                switch (dayOfWeek)
                {
                    case "Friday":
                        totalPrice = countPeople * 15;
                        break;
                    case "Saturday":
                        totalPrice = countPeople * 20;
                        break;
                    case "Sunday":
                        totalPrice = countPeople * 22.50;
                        break;
                }
                if (countPeople >= 10 && countPeople <= 20)
                {
                    totalPrice = 0.95 * totalPrice;
                }
            }
            Console.WriteLine($"Total price: {totalPrice:f2}");
        }
    }
}
