using System;
namespace P01_DataTypeFinder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input;
            string dataType = string.Empty;
            string dataToAnalize = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                dataToAnalize = input;
                if (int.TryParse(dataToAnalize, out _) == true)
                {
                    dataType = "integer";
                }
                else if (float.TryParse(dataToAnalize, out _) == true)
                {
                    dataType = "floating point";
                }
                else if (char.TryParse(dataToAnalize, out _) == true)
                {
                    dataType = "character";
                }
                else if (bool.TryParse(dataToAnalize, out _) == true)
                {
                    dataType = "boolean";
                }
                else
                {
                    dataType = "string";
                }
                Console.WriteLine($"{dataToAnalize} is {dataType} type");
            }
        }
    }
}