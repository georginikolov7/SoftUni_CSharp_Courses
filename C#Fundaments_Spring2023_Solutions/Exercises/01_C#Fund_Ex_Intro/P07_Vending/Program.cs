using System;

namespace P07_Vending
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double balance = 0;
            string command;
            while ((command=Console.ReadLine())!="Start")
            {
                double coins=double.Parse(command);
                if (coins != 0.1 && coins != 0.2 && coins != 0.5 && coins != 1 && coins != 2)
                {
                    Console.WriteLine($"Cannot accept {coins}");
                }
                else balance+=coins;
            }
            bool isInvalid=false;
            while ((command = Console.ReadLine()) != "End")
            {
                double price = 0;
                switch(command)
                {
                    case "Nuts":
                        price = 2;
                        break;
                    case "Water":
                        price = 0.7;
                        break;
                    case "Crisps":
                        price = 1.5;                          
                        break;
                    case "Soda":
                        price = 0.8;
                        break;
                    case "Coke":
                        price = 1;
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        isInvalid = true;
                        break;
                }
                if (isInvalid == true) continue;
                if (price > balance)
                {
                    Console.WriteLine("Sorry, not enough money");
                }
                else
                {
                    Console.WriteLine($"Purchased {command.ToLower()}");
                    balance -= price;
                }
            }
            Console.WriteLine($"Change: {balance:f2}");
        }
    }
}
