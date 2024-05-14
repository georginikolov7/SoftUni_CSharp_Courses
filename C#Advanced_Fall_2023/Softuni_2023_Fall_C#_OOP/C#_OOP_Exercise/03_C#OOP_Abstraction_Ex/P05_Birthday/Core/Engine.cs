using P04_BorderControl.Models;
using P04_BorderControl.Models.Interfaces;
using P05_Birthday.Models;
using P05_Birthday.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace P04_BorderControl.Core
{
    public class Engine
    {
        public void Run()
        {
            List<IBirthable> list = new();
            IBirthable ibirthable = null;
            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                switch (tokens[0])
                {
                    case "Citizen":
                        string name = tokens[1];
                        int age = int.Parse(tokens[2]);
                        string id = tokens[3];
                        string birthdate = tokens[4];
                        ibirthable = new Citizen(name, age, id, birthdate);
                        break;
                    case "Pet":
                        string petName = tokens[1];
                        string petBirthdate = tokens[2];
                        ibirthable = new Pet(petName, petBirthdate);
                        break;
                    default:
                        continue;
                }
                list.Add(ibirthable);
            }
            string year = Console.ReadLine();
            PrintIBirthableInAYear(list,year);
        }

        private void PrintIBirthableInAYear(List<IBirthable> list, string? year)
        {
            string pattern = @"(?<day>([0-2][0-9])|([3][01]))/(?<month>([0][1-9])|([1][0-2]))/(?<year>\d{4})";
            foreach (IBirthable ibirthable in list) 
            {
                Match match=Regex.Match(ibirthable.Birthdate, pattern);
                if (match.Groups["year"].Value == year)
                {
                    Console.WriteLine(ibirthable.Birthdate);
                }
            }
        }
    }
}
