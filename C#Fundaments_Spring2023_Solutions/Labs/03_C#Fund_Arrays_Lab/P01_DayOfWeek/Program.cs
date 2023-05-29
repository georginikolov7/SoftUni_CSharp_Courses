namespace P01_DayOfWeek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int indexOfDay=int.Parse(Console.ReadLine());
            string[] days = { "Monday", "Tuesday","Wednesday","Thursday", 
                "Friday", "Saturday","Sunday"};
            if(indexOfDay>=1 &&indexOfDay<=7)
            Console.WriteLine(days[indexOfDay-1]);
            else
            {
                Console.WriteLine("Invalid day!");
            }
            
        }
    }
}  