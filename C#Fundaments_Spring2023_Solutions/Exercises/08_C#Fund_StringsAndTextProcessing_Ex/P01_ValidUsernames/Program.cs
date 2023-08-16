
namespace P01_ValidUsernames
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> usernames = Console.ReadLine()
                .Split(", ")
                .ToList();

            foreach (string username in usernames)
            {
                if (username.Length < 3 || username.Length > 16)
                {
                    continue;

                }
                bool isValid = username.All(character => char.IsLetterOrDigit(character) || character == '-' || character == '_');
                if(isValid)
                {
                    Console.WriteLine(username);
                }
                //bool flag = false;
                //List<char> chars = username.ToCharArray().ToList();
                //foreach (char c in chars)
                //{
                //    if (!(char.IsLetterOrDigit(c) || c == '-' || c == '_'))
                //    {
                //        flag = true;
                //        break;
                //    }
                //}

                //if (flag == true)
                //{
                //    continue;
                //}
                //Console.WriteLine(username);
            }

        }
    }
}