
public class Program
{
    private static int[] array;
    static void Main()
    {
        array = Console.ReadLine()
       .Split(" ", StringSplitOptions.RemoveEmptyEntries)
       .Select(int.Parse)
       .ToArray();

        int exceptionCount = 0;
        while (exceptionCount < 3)
        {
            string[] tokens = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string command = tokens[0];
            try
            {
                switch (command)
                {
                    case "Replace":
                        int replaceIndex = int.Parse(tokens[1]);
                        int replaceElement = int.Parse(tokens[2]);
                        Replace(replaceIndex, replaceElement);
                        break;
                    case "Show":
                        int showIndex = int.Parse(tokens[1]);
                        Show(showIndex);
                        break;
                    case "Print":
                        Print(int.Parse(tokens[1]), int.Parse(tokens[2]));
                        break;
                }
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("The index does not exist!");
                exceptionCount++;
            }
            catch (FormatException)
            {
                Console.WriteLine("The variable is not in the correct format!");
                exceptionCount++;
            }
        }
        Console.WriteLine(string.Join(", ", array));
    }

    private static void Print(int startIndex, int endIndex)
    {
        List<int> output = new();

        for (int i = startIndex; i <= endIndex; i++)
        {
            output.Add(array[i]);
        }
        Console.WriteLine(string.Join(", ", output));
    }

    private static void Show(int showIndex)
    {
        Console.WriteLine(array[showIndex]);
    }

    private static void Replace(int index, int value)
    {
        array[index] = value;
    }
}