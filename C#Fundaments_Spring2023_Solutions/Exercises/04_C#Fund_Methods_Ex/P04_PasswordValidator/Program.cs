using System.Text.RegularExpressions;

namespace P04_PasswordValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string password=Console.ReadLine();
            bool isBetween6And10Chars = IsBetween6And10Chars(password);
            bool containsOnlyNumbersAndLetters = ContainsOnlyNumbersAndLetters(password);
            bool hasAtLeast2Digits = HasAtLeast2Digits(password);
            if (isBetween6And10Chars && containsOnlyNumbersAndLetters && hasAtLeast2Digits)
            {
                Console.WriteLine("Password is valid");
            }
        }
        static bool IsBetween6And10Chars(string password)
        {
            if(password.Length>=6&&password.Length<=10)return true;
            else
            {
                Console.WriteLine("Password must be between 6 and 10 characters");
                return false;
            }
        }
        static bool ContainsOnlyNumbersAndLetters(string password)
        {
            //bool condIsMet=Regex.IsMatch(password, "^[a-zA-Z0-9]+$");
            //if(!condIsMet)
            //{
            //    Console.WriteLine("Password must consist only of letters and digits");
            //    return false;
            //}
            //else return true;
            foreach (char c in password)
            {
                if (!Char.IsLetterOrDigit(c))
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                    return false;
                }
            }
            return true;
        }
        static bool HasAtLeast2Digits(string password)
        {
            int numOfDigits = 0;
            for (int i = 0; i < password.Length; i++)
            {
                if (password[i] >= '0' && password[i] <= '9')
                {
                    numOfDigits++;
                }
                
            }
            if(numOfDigits>=2)return true;
            else
            {
                Console.WriteLine("Password must have at least 2 digits");
                return false;
            }
            
        }
    }
}