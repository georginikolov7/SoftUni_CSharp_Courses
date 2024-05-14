namespace CustomStack
{
    public class StartUp
    {
        static void Main()
        {
            CustomStack<string> stack = new CustomStack<string>();

            string command;
            while((command = Console.ReadLine()) != "END")
            {
                string[] tokens = command.Split(new char[] { ' ',',' },StringSplitOptions.RemoveEmptyEntries);
                switch (tokens[0])
                {
                    case "Push":
                        string[] itemsToPush= tokens.Skip(1).ToArray();
                        stack.Push(itemsToPush);
                        break;
                    case "Pop":
                        try
                        {
                            stack.Pop(); 
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                        break;
                }
            }
            foreach(string item in stack)
            {
                Console.WriteLine(item);
            }
            foreach (string item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}