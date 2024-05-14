
namespace P08_SoftUniParking
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> guests= new HashSet<string>();
            string input;
            while((input = Console.ReadLine()) !="PARTY") 
            {
                guests.Add(input);
            }
            while ((input = Console.ReadLine()) != "END")
            {
                guests.Remove(input);
            }
            Console.WriteLine(guests.Count());
            foreach (string guest in guests.Where(x => char.IsDigit(x[0])))
            {
                Console.WriteLine(guest);
                guests.Remove(guest);
            }
            foreach(string guest in guests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}