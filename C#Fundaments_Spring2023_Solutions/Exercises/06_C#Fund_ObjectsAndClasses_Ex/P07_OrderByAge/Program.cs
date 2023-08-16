namespace P07_OrderByAge
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] arguments = input.Split();
                string currentName = arguments[0];
                string currentId = arguments[1];
                int currentAge = int.Parse(arguments[2]);
                if (!PersonIsOnList(people, currentId))
                {
                    people.Add(new Person(currentName, currentId, currentAge));
                }
                else
                {
                    ChangePersonCredentials(people, currentName, currentId, currentAge);
                }
            }

            PrintAll(people);
        }

        static void PrintAll(List<Person> people)
        {
            foreach (Person person in people.OrderBy(x=>x.Age)) 
            {
                Console.WriteLine(person);
            }
        }

        static void ChangePersonCredentials(List<Person> people, string currentName, string currentId, int currentAge)
        {
            int index = people.FindIndex(x => x.ID == currentId);
            people[index].Age = currentAge;
            people[index].Name = currentName;

        }

        static bool PersonIsOnList(List<Person> people, string currentId)
        {
            return people
                .Where(x => x.ID == currentId)
                .Any();
        }
    }
    class Person
    {
        public Person(string name, string iD, int age)
        {
            Name = name;
            ID = iD;
            Age = age;
        }

        public string Name { get; set; }
        public string ID { get; set; }
        public int Age { get; set; }
        public override string ToString()
        {
            return $"{Name} with ID: {ID} is {Age} years old.";
        }
    }
}