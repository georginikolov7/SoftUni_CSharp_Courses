using System;

namespace P05_Login
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string username = Console.ReadLine();
            
            char[] arr= username.ToCharArray();
            Array.Reverse(arr);
            string correctPass =new string(arr);
            int numberOfAttempts = 0;
            string currPass;
            bool isBlocked = false;
            while ((currPass = Console.ReadLine()) != correctPass)
            {
                numberOfAttempts++;
                if (numberOfAttempts == 4)
                {
                    isBlocked = true;
                    break;
                }

                Console.WriteLine("Incorrect password. Try again.");
            }

            if (isBlocked == true)
            {
                Console.WriteLine($"User {username} blocked!");
            }

            else
            {
                Console.WriteLine($"User {username} logged in.");
            }
            
        
        }
    }
}
