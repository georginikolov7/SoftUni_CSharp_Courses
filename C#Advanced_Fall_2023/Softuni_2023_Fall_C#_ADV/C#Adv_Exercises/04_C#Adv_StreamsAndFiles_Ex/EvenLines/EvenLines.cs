using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EvenLines;

public class EvenLines
{
    static void Main()
    {
        string inputFilePath = @"..\..\..\text.txt";

        Console.WriteLine(ProcessLines(inputFilePath));
    }

    public static string ProcessLines(string inputFilePath)
    {
        StringBuilder sb = new();
        using (StreamReader reader = new StreamReader(inputFilePath))
        {
            int count = 0;
            while (reader.EndOfStream == false)
            {
                string line = reader.ReadLine();
                if (count % 2 == 0)
                {
                    string replacedSymbols = ReplaceSymbols(line);
                    string reversed = ReverseOrder(replacedSymbols);
                    sb.AppendLine(reversed);
                }
                count++;
            }
        }

        return sb.ToString().TrimEnd();
    }

    private static string ReplaceSymbols(string line)
    {
        StringBuilder sb = new(line);
        char[] symbolsToReplace = new char[5] { '-', ',', '.', '!', '?' };
        for (int i = 0; i < symbolsToReplace.Length; i++)
        {
            sb.Replace(symbolsToReplace[i], '@');
        }
        return sb.ToString();
    }
    private static string ReverseOrder(string words)
    {
        string[] reversedWords = words
            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
            .Reverse()
            .ToArray();
        return string.Join(" ", reversedWords);
    }

}

