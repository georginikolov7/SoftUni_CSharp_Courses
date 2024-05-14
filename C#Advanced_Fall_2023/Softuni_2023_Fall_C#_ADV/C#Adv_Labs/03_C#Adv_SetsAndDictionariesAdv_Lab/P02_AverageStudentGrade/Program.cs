namespace P02_AverageStudentGrade
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<decimal>> studentGrades = new Dictionary<string, List<decimal>>();
            int numOfInputs = int.Parse(Console.ReadLine());
            for (int i = 0; i < numOfInputs; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = input[0];
                decimal grade = decimal.Parse(input[1]);
                if (!studentGrades.ContainsKey(name))
                {
                    studentGrades.Add(name, new List<decimal>());
                }
                studentGrades[name].Add(grade);
            }
            foreach(var kvp in studentGrades)
            {
                Console.Write($"{kvp.Key} -> ");
                foreach(float num in kvp.Value)
                {
                    Console.Write($"{num:f2} ");
                }
                Console.WriteLine($"(avg: {kvp.Value.Average():f2})");
            }
        }
    }
}