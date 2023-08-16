namespace P05_Courses
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                string[] tokens = input.Split(" : ");
                string courseName = tokens[0];
                string studentName = tokens[1];
                if (!courses.ContainsKey(courseName))
                {
                    courses.Add(courseName, new List<string>());
                }
                courses[courseName].Add(studentName);
            }
            foreach (string courseName in courses.Keys)
            {
                Console.WriteLine($"{courseName}: {courses[courseName].Count}");
                foreach(string student in courses[courseName])
                {
                    Console.WriteLine($"-- {student}");
                }
            }
        }
    }
}