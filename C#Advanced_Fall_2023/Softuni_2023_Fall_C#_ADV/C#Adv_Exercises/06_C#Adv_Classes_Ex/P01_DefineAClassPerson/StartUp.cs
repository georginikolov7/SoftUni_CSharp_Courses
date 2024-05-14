namespace DefiningClasses
{

    public class StartUp
    {
        static void Main(string[] args)
        {
            Family family = new Family();
            int countOfPeople = int.Parse(Console.ReadLine());
            for (int i = 0; i < countOfPeople; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                Person currentMember = new Person(input[0], int.Parse(input[1]));
                family.AddMember(currentMember);
            }
            Console.WriteLine(family.GetOldestMember().ToString());
        }
    }
}