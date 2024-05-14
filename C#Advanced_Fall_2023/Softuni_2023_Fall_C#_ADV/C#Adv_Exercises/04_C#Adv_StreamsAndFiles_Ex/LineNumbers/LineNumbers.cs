namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            StringBuilder sb = new();
            string[] lines = File.ReadAllLines(inputFilePath);
            int count = 1;
            foreach (string line in lines)
            {
                int countLetters = CountLetters(line);
                int countPunctSigns = CountPunctuationSigns(line);
                sb.AppendLine($"Line {count}: {line} ({countLetters})({countPunctSigns})");
            }
            File.WriteAllText(outputFilePath, sb.ToString());
        }

        private static int CountLetters(string line)
        {
            int count = line.Count(ch=>char.IsLetter(ch));           
            return count;
        }
        private static int CountPunctuationSigns(string line)
        {
            int count=line.Count(ch=>char.IsPunctuation(ch));
            return count;
        }

    }
}
