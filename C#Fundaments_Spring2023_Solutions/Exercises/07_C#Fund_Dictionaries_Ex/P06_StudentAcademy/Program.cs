using System.Xml.Linq;

namespace P06_StudentAcademy
{
    class Student
    {
        public Student(string name, List<double> grades)
        {
            Name = name;
            Grades = grades;
        }

        public string Name { get; set; }
        public List<double> Grades { get; set; }

        public double AverageGrade
        {
            get
            {
                return Grades.Sum() / Grades.Count;
            }
        }
        public override string ToString()
        {
            return $"{Name} -> {AverageGrade:f2}";
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            var students = new Dictionary<string, Student>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string currentStudent = Console.ReadLine();
                double currentGrade = double.Parse(Console.ReadLine());
                if (!students.ContainsKey(currentStudent))
                {
                    students.Add(currentStudent, new Student(currentStudent, new List<double>()));
                }
                students[currentStudent].Grades.Add(currentGrade);
            }
            //Check average grades and print
            foreach (var student in students.Values)
            {
                if (student.AverageGrade >= 4.50)
                {
                    Console.WriteLine(student);
                }
            }
        }
    }
}