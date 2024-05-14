namespace DefiningClasses
{
    public class StartUp
    {
        static void Main()
        {
            List<Person> people = new();
            int n=int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] input=Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries);
                people.Add(new Person(input[0], int.Parse(input[1])));
            }
            foreach (Person person in people.Where(p=>p.Age>30).OrderBy(p=>p.Name))
            {
                Console.WriteLine(person);
            }
        }
    }
}