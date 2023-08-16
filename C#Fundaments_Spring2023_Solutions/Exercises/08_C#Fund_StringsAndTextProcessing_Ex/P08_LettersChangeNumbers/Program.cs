using System.Security;

namespace P08_LettersChangeNumbers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            double totalSum = 0;
            foreach (string sequence in input)
            {
                //seq --> A12b
                char firstLetter = sequence[0];
                int number = int.Parse(sequence.Substring(1, sequence.Length - 2));
                char secondLetter = sequence[sequence.Length - 1];

                totalSum += CalculateSum(firstLetter, number, secondLetter);
            }
            Console.WriteLine($"{totalSum:f2}");
        }

        private static double CalculateSum(char firstLetter, int number, char secondLetter)
        {
            double currentSum = number;
            //first letter calculation
            int firstLetterPosition;
            if (char.IsUpper(firstLetter))
            {
                firstLetterPosition = firstLetter - 'A'+1;
                currentSum /= firstLetterPosition;
            }
            else if (char.IsLower(firstLetter))
            {
                firstLetterPosition = firstLetter - 'a'+1;
                currentSum *= firstLetterPosition;
            }
            //second letter calculation
            int secondLetterPosition;
            if (char.IsUpper(secondLetter))
            {
                secondLetterPosition = secondLetter - 'A'+1;
                currentSum -= secondLetterPosition;
            }
            else if (char.IsLower(secondLetter))
            {
                secondLetterPosition = secondLetter - 'a' + 1;
                currentSum += secondLetterPosition;
            }

            return currentSum;
        }
    }
}