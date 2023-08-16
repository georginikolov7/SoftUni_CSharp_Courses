using System.Collections.Generic;
using System.Diagnostics;

namespace P04_Students
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int countOfStudents=int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();
            for (int i = 0; i < countOfStudents; i++)
            {
                string[] input = Console.ReadLine()
                    .Split()
                    .ToArray();
                students.Add(new Student(input[0], input[1], float.Parse(input[2])));
            }
            foreach (Student student in students.OrderByDescending(x=>x.Grade))
            {
                Console.WriteLine(student.ToString());
            }
        }
    }
    class Student
    {
        public Student(string firstName, string lastName, float grade)
        {
            FirstName = firstName;
            LastName = lastName;
            Grade = grade;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public float Grade { get; set; }
        public string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:f2}";
        }
    }
}