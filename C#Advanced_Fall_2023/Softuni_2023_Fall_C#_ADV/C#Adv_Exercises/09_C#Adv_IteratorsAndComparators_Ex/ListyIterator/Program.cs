namespace ListyIteratorType
{
    public class StartUp
    {
        static void Main()
        {
            string input = Console.ReadLine();
            string[] tokens = input
                            .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                            .Skip(1)
                            .ToArray();
            ListyIterator<string> listyIterator = new(tokens.ToList());
            while ((input = Console.ReadLine()) != "END")
            {
                switch (input)
                {
                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;
                    case "Print":
                        try
                        {
                            listyIterator.Print();

                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                    case "PrintAll":
                        try
                        {
                            listyIterator.PrintAll();
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                }
            }
        }
    }
}