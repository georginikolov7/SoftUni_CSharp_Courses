using System;
namespace P03_Elevator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfPeople = int.Parse(Console.ReadLine());
            int elevatorCap=int.Parse(Console.ReadLine());
            int courses=numberOfPeople/elevatorCap;
            if(numberOfPeople%elevatorCap!=0 )
            {
                courses++;
            }
            Console.WriteLine(courses);
        }
    }
}