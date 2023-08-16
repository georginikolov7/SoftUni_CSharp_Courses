

using System.Data;

namespace P04_Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            List<Student> students = new List<Student>();
            while ((input = Console.ReadLine()) != "end")
            {
                List<string> data = input.Split().ToList();
                string firstName = data[0];
                string lastName = data[1];
                int age = int.Parse(data[2]);
                string hometow= data[3];
                Student existingStudent = students.FirstOrDefault(x => x.FirstName == data[0] && x.LastName == data[1]);
                if (existingStudent == null)
                {
                    students.Add(new Student(firstName,lastName, age,hometow));
                }
                else
                {
                    existingStudent.Age = int.Parse(data[2]);
                    existingStudent.Hometown = data[3];
                }
            }
            string cityName = Console.ReadLine();
            for (int i = 0; i < students.Count; i++)
            {
                if (students[i].Hometown == cityName)
                {
                    Console.WriteLine($"{students[i].FirstName} {students[i].LastName} is {students[i].Age} years old.");
                }
            }
        }

        

    }
    class Student
    {
        public Student(string firstName, string lastName, int age, string hometown)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Hometown = hometown;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string Hometown { get; set; }

    }
}